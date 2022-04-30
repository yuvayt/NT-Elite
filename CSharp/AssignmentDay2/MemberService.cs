using System;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentDay2
{
    public class MemberService
    {
        public static List<Member> InitMembers()
        {
            return new List<Member>{
             new Member("Bo", "Tran", "Bio", new DateTime(2021, 6, 9), "01234435", "HCM", false),
             new Member("Da", "Nguyen", "Male", new DateTime(1969, 6, 9), "01234435", "HN", true),
             new Member("Banh", "Kha", "Male", new DateTime(2000, 6, 9), "01234435", "HCM", false),
             new Member("Huan", "Rose", "Male", new DateTime(1999, 6, 8), "01234435", "HCM", true),
             new Member("Tien", "Bip", "Male", new DateTime(2001, 6, 9), "01234435", "HN", true)
            };
        }

        public static IEnumerable<Member> GetMaleMembers(List<Member> members)
        {
            return members.FindAll(member => member.Gender == "Male").DefaultIfEmpty();
        }

        public static Member GetOldestMember(List<Member> members)
        {
            int maxAge = members.Max(x => x.Age);
            Member member = members.FirstOrDefault(x => x.Age == maxAge);
            Member oldestMember = members.Aggregate((memberA, memberB) => memberA.Age < memberB.Age ? memberB : memberA);

            return oldestMember;
        }

        public static IEnumerable<string> GetMembersFullName(List<Member> members)
        {
            IEnumerable<string> fullNames = members.Select(member => member.FullName);

            return fullNames;
        }

        public static void Get3Lists(int i, List<Member> members)
        {
            switch (i)
            {
                case 1:
                    Console.WriteLine("4. List of members who has birth year greater than 2000:");
                    PrintListMembers(GetGreater2K(members));
                    break;
                case -1:
                    Console.WriteLine("4. List of members who has birth year less than 2000:");
                    PrintListMembers(GetLess2K(members));
                    break;
                default:
                    Console.WriteLine("4. List of members who has birth year is 2000:");
                    PrintListMembers(Get2K(members));
                    break;
            }
        }

        public static IEnumerable<Member> Get2K(List<Member> members)
        {
            IEnumerable<Member> is2ks = members.Where(member => member.Dob.Year == 2000).ToList();

            return is2ks;
        }

        public static IEnumerable<Member> GetGreater2K(List<Member> members)
        {
            IEnumerable<Member> greater2ks = members.Where(member => member.Dob.Year > 2000).ToList();

            return greater2ks;
        }

        public static IEnumerable<Member> GetLess2K(List<Member> members)
        {
            IEnumerable<Member> less2ks = members.Where(member => member.Dob.Year < 2000);

            return less2ks;
        }

        public static Member GetHanoian(List<Member> members)
        {
            Member hanoian = members.Find(member => member.BirthPlace == "HN");

            return hanoian;
        }

        public static void PrintListMembers(IEnumerable<Member> members)
        {
            var infos = members.Select(x => x.FullInfo);
            foreach (var info in infos)
            {
                Console.WriteLine(info);
                Console.WriteLine();
            }
        }
    }
}