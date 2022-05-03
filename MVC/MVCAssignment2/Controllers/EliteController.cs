using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCAssignment2.Models;
using MVCAssignment2.Services;

namespace MVCAssignment2.Controllers
{
    public class EliteController : Controller
    {
        private readonly ILogger<EliteController> _logger;

        private static List<Member> members = MemberService.InitMembers();

        public EliteController(ILogger<EliteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string ShowMaleMembers()
        {
            IEnumerable<Member> maleMembers = MemberService.GetMaleMembers(members);

            return string.Join("\n\r", maleMembers.Select(member => member.FullInfo));
        }

        public IActionResult ShowOldestMember()
        {
            return Ok(MemberService.GetOldestMember(members).FullInfo);
        }

        public IActionResult ShowMembersFullName()
        {
            IEnumerable<string> fullNames = MemberService.GetMembersFullName(members);

            return Ok(fullNames);
        }

        public IActionResult ShowViaQueryString(string id)
        {

            if (id == "0")
            {
                return RedirectToAction("ShowLess2K");
            }

            if (id == "2")
            {
                return RedirectToAction("ShowGreater2K");
            }

            return RedirectToAction("Show2K");
        }

        public string ShowGreater2K()
        {
            IEnumerable<Member> greater2ks = MemberService.GetGreater2K(members);

            return string.Join("\n\r", greater2ks.Select(member => member.FullInfo));
        }

        public string ShowLess2K()
        {
            IEnumerable<Member> less2ks = MemberService.GetLess2K(members);

            return string.Join("\n\r", less2ks.Select(member => member.FullInfo));
        }

        public string Show2K()
        {
            IEnumerable<Member> is2ks = MemberService.Get2K(members);

            return string.Join("\n\r", is2ks.Select(member => member.FullInfo));
        }

        public string ShowFullMembers()
        {
            ExportService.ExportToExcel(@"member.xlsx", members, "Member");

            return string.Join("\n\r", members.Select(member => member.FullInfo));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}