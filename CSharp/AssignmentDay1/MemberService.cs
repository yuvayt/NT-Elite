using System;
using System.Collections.Generic;

namespace AssignmentDay1
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

        public static List<Member> GetMaleMembers(List<Member> members)
        {
            List<Member> maleMembers = new List<Member>();

            foreach (Member member in members)
            {
                if (member.Gender == "Male")
                {
                    maleMembers.Add(member);
                }
            }

            return maleMembers;
        }

        public static Member GetOldestMember(List<Member> members)
        {
            Member oldestMember = members[0];

            for (int i = 1; i < members.Count; i++)
            {
                if (members[i].Dob < oldestMember.Dob)
                    oldestMember = members[i];
            }

            return oldestMember;
        }

        public static List<string> GetMembersFullName(List<Member> members)
        {
            List<string> fullNames = new List<string>();

            foreach (Member member in members)
            {
                fullNames.Add(member.GetFullName());
            }

            return fullNames;
        }

        public static void Get3Lists(int i, List<Member> members)
        {
            switch (i)
            {
                case 1:
                    Console.WriteLine
                    (
                        "4. Members who has birth year greater than 2000:"
                    );
                    PrintListMembers(GetGreater2K(members));
                    break;
                case -1:
                    Console.WriteLine
                    (
                        "4. Members who has birth year less than 2000:"
                    );
                    PrintListMembers(GetLess2K(members));
                    break;
                default:
                    Console.WriteLine
                    (
                        "4. Members who has birth year is 2000:"
                    );
                    PrintListMembers(Get2K(members));
                    break;
            }
        }

        public static List<Member> Get2K(List<Member> members)
        {
            List<Member> is2ks = new List<Member>();

            foreach (Member member in members)
            {
                if (member.Dob.Year == 2000)
                    is2ks.Add(member);
            }

            return is2ks;
        }

        public static List<Member> GetGreater2K(List<Member> members)
        {
            List<Member> greater2ks = new List<Member>();

            foreach (Member member in members)
            {
                if (member.Dob.Year > 2000)
                    greater2ks.Add(member);
            }

            return greater2ks;
        }

        public static List<Member> GetLess2K(List<Member> members)
        {
            List<Member> less2ks = new List<Member>();

            foreach (Member member in members)
            {
                if (member.Dob.Year < 2000)
                    less2ks.Add(member);
            }

            return less2ks;
        }

        public static Member GetHanoian(List<Member> members)
        {
            Member hanoian;
            int i = 0;

            while (true)
            {
                if (members[i].BirthPlace == "HN")
                {
                    hanoian = members[i];
                    break;
                }
                i++;
            }

            return hanoian;
        }

        public static void PrintListMembers(List<Member> members)
        {
            foreach (Member member in members)
            {
                Console.WriteLine(member.FullInfo);
                Console.WriteLine();
            }
        }
    }
}