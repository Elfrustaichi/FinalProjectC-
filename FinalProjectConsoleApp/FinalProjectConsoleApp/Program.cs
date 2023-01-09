using FinalProjectConsoleApp.Service.Implemetations;


int Order;
GroupService Service = new GroupService();
repeat:

Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine("Hello welcome to our PrincipalCademy");
Console.WriteLine("Select your Order below.");
Console.WriteLine("1.Create new Group.");
Console.WriteLine("2.Show all groups.");
Console.WriteLine("3.Edit Group.");
Console.WriteLine("4.Show students of specific group.");
Console.WriteLine("5.Show All students.");
Console.WriteLine("6.Create student.");
Console.WriteLine("0.Exit.");
Console.Write("Your order----");


if (int.TryParse(Console.ReadLine(), out Order))
{
    switch (Order)
    {
        case 1:
            Console.Clear();
            MenuService.CreateGroupMenu();
            goto repeat;
        case 2:
            Console.Clear();
            MenuService.ShowAllGroupsMenu();
            goto repeat;
        case 3:
            Console.Clear();
            MenuService.EditGroupMenu();
            goto repeat;
        case 4:
            Console.Clear();
            MenuService.ShowSpecificGroupStudentsMenu();
            goto repeat;
        case 5:
            Console.Clear();
            MenuService.ShowAllStudentsMenu();
            goto repeat;
        case 6:
            Console.Clear();
            MenuService.CreateStudentMenu();
            goto repeat;
        case 0:
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Exiting....");
            Console.BackgroundColor = ConsoleColor.Black;
            return;
        default:
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Please correct order.");
            goto repeat;

    }
}
else
{
    Console.Clear();
    Console.BackgroundColor = ConsoleColor.Red;
    Console.WriteLine("Please enter valid order.");
    goto repeat;
}