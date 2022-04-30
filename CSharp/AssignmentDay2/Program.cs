using System;
using System.Collections.Generic;

namespace AssignmentDay2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Member> members = MemberService.InitMembers();

            IEnumerable<Member> maleMembers = MemberService.GetMaleMembers(members);
            Console.WriteLine("1. List of Male members:");
            MemberService.PrintListMembers(maleMembers);

            Console.WriteLine("2. Oldest Member: "
            + MemberService.GetOldestMember(members).FullName);
            Console.WriteLine();

            IEnumerable<string> fullNames = MemberService.GetMembersFullName(members);
            Console.WriteLine("3. List of members's fullname:");
            foreach (string fullName in fullNames)
                Console.WriteLine(fullName);
            Console.WriteLine();

            Console.WriteLine
            (
                "1: List of members who has birth year greater than 2000 \r\n"
                + "-1: List of members who has birth year less than 2000 \r\n"
                + "Other number: List of members "
                + "who has birth year less than 2000"
            );
            int input = Int32.Parse(Console.ReadLine());
            MemberService.Get3Lists(input, members);

            Member hanoian = MemberService.GetHanoian(members);
            Console.WriteLine("5. Person born in Hanoi: " + hanoian.FullName);
        }
    }
}
