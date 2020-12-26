using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
	[Authorize]
	public class BorrowController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly LibraryContext _context;

		public BorrowController(UserManager<ApplicationUser> userManager, LibraryContext context)
		{
			_userManager = userManager;
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var UserResult = await _userManager.GetUserAsync(User);
			if (UserResult == null)
			{
				return RedirectToAction("InternalError", "Error");
			}

			var borrowList = await _context.Borrow.Where(e => e.ReaderId == UserResult.Id).ToListAsync();

			List<BorrowDetailViewModel> borrowDetailViewModelList = new List<BorrowDetailViewModel>();

			foreach (var item in borrowList)
			{
				var currentBook = await _context.Books.FindAsync(item.BookId);
				borrowDetailViewModelList.Add(new BorrowDetailViewModel
				{
					BorrowId = item.Id,
					BookId = item.BookId,
					BookName = currentBook.BookName,
					UserId = UserResult.Id,
					UserName = UserResult.UserName,
					BorrowContinueTimes = UserResult.UserBorrowQuantity,
					LendDate = item.LendDate,
					ExpectReturnDate = item.ExpectReturnDate,
					DelayDays = item.DelayDays,
					DelayExpense = item.DelayExpense,
					BookCover = currentBook.BookCover
					//BookName = _context.Books.Find(item.BookId).BookName
				});
			}

			return View(borrowDetailViewModelList);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Borrow(uint? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var book = await _context.Books.FindAsync(id);
			if (book == null)
			{
				return NotFound();
			}
			if (book.BookStatusId != 0)
			{
				return NotFound();
			}
			var UserResult = _userManager.GetUserAsync(User).Result;
			var borrow = new BorrowViewModel
			{
				BookId = book.BookId,
				BookName = book.BookName,

				UserId = UserResult.Id,
				UUID = UserResult.UUID,
				UserName = UserResult.UserName,
			};

			return View(borrow);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Borrow(uint? bookId, string userId)
		{
			if (bookId == null)
			{
				return NotFound();
			}
			var BookResult = _context.Books.FirstOrDefaultAsync(b => b.BookId == bookId).Result;
			var UserResult = _userManager.FindByIdAsync(userId).Result;
			if (BookResult == null || UserResult == null)
			{
				return NotFound();
			}
			else
			{
				var borrow = new Borrow
				{
					BookId = (uint)bookId,
					ReaderId = UserResult.Id,
					BorrowContinueTimes = 0,
					LendDate = DateTime.Now,
					ExpectReturnDate = DateTime.Now.AddMonths(1),
					DelayDays = 0,
					DelayExpense = 0,
					LendOperatorId = (uint)UserResult.UUID
				};

				try
				{
					_context.Borrow.Add(borrow);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!BorrowExists((uint)bookId, userId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
			}
			return RedirectToAction(nameof(Index));
		}

		private bool BorrowExists(uint BookId, string UserId)
		{
			return _context.Borrow.Any(e => e.BookId == BookId && e.ReaderId == UserId);
		}

		// GET: Borrow/Delete/5
		public async Task<IActionResult> Delete(uint? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var borrow = await _context.Borrow.FirstOrDefaultAsync(m => m.Id == id);
			if (borrow == null)
			{
				return NotFound();
			}

			var BorrowDetailViewModel = new BorrowDetailViewModel
			{
				BorrowId = borrow.Id,
				LendDate = borrow.LendDate,
				ExpectReturnDate = borrow.ExpectReturnDate,
				DelayDays = borrow.DelayDays,
				DelayExpense = borrow.DelayExpense,
				RemainingDays = CountRemainDays(borrow.ExpectReturnDate)
			};

			return View(BorrowDetailViewModel);
		}

		// POST: Borrow/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(uint id)
		{
			var borrow = await _context.Borrow.FindAsync(id);
			_context.Borrow.Remove(borrow);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool BorrowExists(uint id)
		{
			return _context.Borrow.Any(e => e.Id == id);
		}

		public int CountRemainDays(DateTime? Time)
		{
			if (Time.HasValue)
			{
				return (int)(Time.Value - DateTime.Now).TotalDays;
			}
			else
			{
				return -1;
			}
		}

		[HttpGet]
		public async Task<IActionResult> Extend(uint? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var borrow = await _context.Borrow.FirstOrDefaultAsync(m => m.Id == id);
			if (borrow == null)
			{
				return NotFound();
			}

			var BorrowDetailViewModel = new BorrowDetailViewModel
			{
				BorrowId = borrow.Id,
				LendDate = borrow.LendDate,
				ExpectReturnDate = borrow.ExpectReturnDate,
				DelayDays = borrow.DelayDays,
				DelayExpense = borrow.DelayExpense,
				RemainingDays = CountRemainDays(borrow.ExpectReturnDate)
			};

			return View(BorrowDetailViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Extend(uint BorrowId, int RemainingDays)
		{
			var borrow = await _context.Borrow.FindAsync(BorrowId);
			if (borrow == null)
			{
				return NotFound();
			}

			borrow.ExpectReturnDate = ((DateTime)borrow.ExpectReturnDate).AddMonths(RemainingDays);
			try
			{
				_context.Update(borrow);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!BorrowExists(borrow.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return RedirectToAction(nameof(Index));

		}
	}
}
