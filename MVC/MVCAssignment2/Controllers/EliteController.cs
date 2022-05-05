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

        public IActionResult ListMembers()
        {
            return View(_memberService.GetMembersByOrder());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Member newMember)
        {
            if (newMember == null)
            {
                return null;
            }

            _memberService.AddNewMember(newMember);

            return RedirectToAction("ListMembers");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var member = _memberService.GetMemberById((int)id);

            if (member == null)
            {
                return null;
            }

            return View(member);
        }

        [HttpPost]
        public IActionResult Edit(Member updateMember)
        {
            if (!_memberService.UpdateMember(updateMember))
            {
                return null;
            }

            return RedirectToAction("ListMembers");
        }

        public IActionResult Delete(int? id)
        {
            if (!_memberService.RemoveMember(id))
            {
                return null;
            }

            return RedirectToAction("ListMembers");
        }

        public IActionResult ListMaleMembers()
        {
            IEnumerable<Member> maleMembers = _memberService.GetMaleMembers();

            return View(maleMembers);
        }

        public IActionResult ShowOldestMember()
        {
            var oldestMember = _memberService.GetOldestMember();

            return View(oldestMember);
        }

        public IActionResult ListMembersFullName()
        {
            IEnumerable<string> fullNames = _memberService.GetMembersFullName();

            return View(fullNames);
        }

        public IActionResult ListViaValue(int id)
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