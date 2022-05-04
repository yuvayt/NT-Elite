using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using MVCAssignment2.Models;
using MVCAssignment2.Services;

namespace MVCAssignment2.Controllers
{
    public class EliteController : Controller
    {
        public MemberService _memberService;
        public ExportService _exportService;

        public EliteController()
        {
            if (_memberService == null)
            {
                _memberService = new MemberService();
            }

            _exportService = new ExportService();
        }

        public IActionResult ShowFullMembers()
        {
            return View(_memberService.Members);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Member newMember)
        {
            newMember.Id = _memberService.GetNextId();

            return RedirectToAction("ShowFullmembers");
        }

        public IActionResult Edit(int id)
        {
            var member = _memberService.GetMemberById(id);

            return View(member);
        }

        [HttpPost]
        public IActionResult Edit(Member updateMember)
        {
            _memberService.UpdateMember(updateMember);

            return RedirectToAction("ShowFullmembers");
        }

        public IActionResult ShowMaleMembers()
        {
            IEnumerable<Member> maleMembers = _memberService.GetMaleMembers();

            return View(maleMembers);
        }

        public IActionResult ShowOldestMember()
        {
            var oldestMember = _memberService.GetOldestMember();

            return Content(oldestMember.FullInfo);
        }

        public IActionResult ShowMembersFullName()
        {
            IEnumerable<string> fullNames = _memberService.GetMembersFullName();

            return Ok(fullNames);
        }

        public IActionResult ShowViaValue(int id)
        {
            IEnumerable<Member> result = _memberService.GetViaValue(id);

            return Ok(result);
        }

        public IActionResult DownloadMembersExcel()
        {
            var fileName = "member.xlsx";
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var package = _exportService.ExportToExcel(_memberService.Members, "Members");

            var fileStream = new MemoryStream();
            package.SaveAs(fileStream);
            fileStream.Position = 0;

            var fsr = new FileStreamResult(fileStream, contentType);
            fsr.FileDownloadName = fileName;

            return fsr;
        }
    }
}