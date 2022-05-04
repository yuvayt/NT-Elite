using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using MVCAssignment2.Models;

namespace MVCAssignment2.Services
{
    public class MemberService
    {

        private static List<Member> _members;

        public List<Member> Members
        {
            get
            {
                if (_members != null)
                {
                    return _members;
                }
                else
                {
                    return InitDummyMembers();
                }
            }
        }
        public MemberService()
        {
            if (_members == null)
            {
                _members = InitDummyMembers();
            }
        }
        private List<Member> InitDummyMembers()
        {
            return new List<Member>{
             new Member(1, "Bo", "Tran", "Bio", new DateTime(2021, 6, 9), "01234435", "HCM", false),
             new Member(2, "Da", "Nguyen", "Male", new DateTime(1969, 6, 9), "01234435", "HN", true),
             new Member(3, "Banh", "Kha", "Male", new DateTime(2000, 6, 9), "01234435", "HCM", false),
             new Member(4, "Huan", "Rose", "Male", new DateTime(1999, 6, 8), "01234435", "HCM", true),
             new Member(5, "Tien", "Bip", "Male", new DateTime(2001, 6, 9), "01234435", "HN", true)
            };
        }

        public Member GetMemberById(int id)
        {
            var member = Members.Where(member => member.Id == id).FirstOrDefault();

            return member;
        }

        public int GetNextId()
        {
            int? maxId = Members.Max(member => member.Id);
            if (maxId == null)
            {
                maxId = 0;
            }

            return (int)(maxId + 1);
        }

        public void AddNewMember(Member newMember)
        {

        }

        public void UpdateMember(Member updateMember)
        {
            Member member = GetMemberById(updateMember.Id);
            _members.Remove(member);
            _members.Add(updateMember);
        }

        public IEnumerable<Member> GetMaleMembers()
        {
            return Members.FindAll(member => member.Gender == "Male").DefaultIfEmpty();
        }

        public Member GetOldestMember()
        {
            int maxAge = Members.Max(x => x.Age);
            Member oldestMember = Members.FirstOrDefault(x => x.Age == maxAge);

            return oldestMember;
        }

        public IEnumerable<string> GetMembersFullName()
        {
            IEnumerable<string> fullNames = Members.Select(member => member.FullName);

            return fullNames;
        }

        public IEnumerable<Member> GetViaValue(int id)
        {
            switch (id)
            {
                case 0:
                    return GetLess2K();
                case 2:
                    return GetGreater2K();
                default:
                    return Get2K();
            }
        }

        public IEnumerable<Member> Get2K()
        {
            IEnumerable<Member> member2ks = Members.Where(member => member.Dob.Year == 2000).ToList();

            return member2ks;
        }

        public IEnumerable<Member> GetGreater2K()
        {
            IEnumerable<Member> greater2ks = Members.Where(member => member.Dob.Year > 2000).ToList();

            return greater2ks;
        }

        public IEnumerable<Member> GetLess2K()
        {
            IEnumerable<Member> less2ks = Members.Where(member => member.Dob.Year < 2000);

            return less2ks;
        }
    }
}