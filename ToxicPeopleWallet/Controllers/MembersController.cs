using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToxicPeopleWallet.Data;
using ToxicPeopleWallet.Models;
using ToxicPeopleWallet.Models.Enums;
using ToxicPeopleWallet.ViewModels;

namespace ToxicPeopleWallet.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MembersController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // -------------------------------------------------
        // Member Contribution Overview
        // -------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users
                .OrderBy(x => x.FullName)
                .ToListAsync();


            var transactions = await _context.WalletTransactions
                .ToListAsync();


            var members =
                new List<MemberContributionViewModel>();


            foreach (var user in users)
            {
                // Do not show Admin account
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    continue;
                }


                var userTransactions = transactions
                    .Where(x => x.UserId == user.Id)
                    .ToList();


                var totalDeposited = userTransactions
                    .Where(x =>
                        x.Type == TransactionType.Deposit &&
                        x.Status == TransactionStatus.Approved)
                    .Sum(x => x.Amount);


                var totalExpenses = userTransactions
                    .Where(x =>
                        x.Type == TransactionType.Withdrawal &&
                        x.Status == TransactionStatus.Approved)
                    .Sum(x => x.Amount);


                var pendingRequests = userTransactions
                    .Count(x =>
                        x.Status == TransactionStatus.Pending);


                members.Add(
                    new MemberContributionViewModel
                    {
                        UserId = user.Id,

                        FullName = user.FullName,

                        Email = user.Email ?? string.Empty,

                        TotalDeposited = totalDeposited,

                        TotalExpenses = totalExpenses,

                        CurrentBalance = user.CurrentBalance,

                        PendingRequests = pendingRequests
                    });
            }


            return View(members);
        }
    }
}