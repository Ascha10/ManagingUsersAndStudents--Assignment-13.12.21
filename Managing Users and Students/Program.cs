using ManagingUsersAndStudents;

List<User> usersList = new List<User>();

Console.WriteLine("Please Select The Options");
Console.WriteLine("1. Add User");
Console.WriteLine("2. Edit User");
Console.WriteLine("3. Delete User");
Console.WriteLine("4. Display Specific User");
int selectedOption = int.Parse(Console.ReadLine());

void Menu()
{
    switch (selectedOption)
    {
        case 1:
            AddUser();
            break;
        case 2:
            Console.WriteLine("Please Enter File Name");
            EditUser(Console.ReadLine());
            break;
        case 3:
            Console.WriteLine("Please Enter File Name");
            DeleteUser(Console.ReadLine());
            break;
        case 4:
            Console.WriteLine("Please Enter File Name");
            GetDataFromUserFile(Console.ReadLine());
            break;

        default:
            Menu();
            break;
    }
}

Menu();

void CreateUseres()
{
    int count = 0;
    while (count < 3)
    {
        Console.WriteLine("Please Enter firstName,lastName,yearOfBirth,eamil");
        usersList.Add(new User(Console.ReadLine(), Console.ReadLine(), int.Parse(Console.ReadLine()), Console.ReadLine()));
        usersList.Sort();
        foreach (User user in usersList)
        {
            Console.WriteLine($"{user.FirstName} {user.LastName} {user.YearOfBirth} {user.Email}");
        }

        count++;
    }
}

//CreateUseres();

void GetDataAndWriteToFile(List<User> userList)
{
    FileStream fileStreamObject = new FileStream(@"C:\test\Users\users.txt", FileMode.Append);
    using (StreamWriter writeToUserFile = new StreamWriter(fileStreamObject))
    {    
        foreach (User user in usersList)
        {
            writeToUserFile.Write($"{user.FirstName} {user.LastName} {user.YearOfBirth} {user.Email}\n");
        }
    }
}

//GetDataAndWriteToFile(usersList);

void GetDataAndPrintToConsole(string filePath)
{
    FileStream fileStreamObject = new FileStream($@"C:\test\Users\{filePath}.txt", FileMode.Open);
    using (StreamReader readFromUserFile = new StreamReader(fileStreamObject))
    {
        for (int i = 0; i < readFromUserFile.Peek(); i++)
        {
            Console.WriteLine(readFromUserFile.ReadLine()); 
        }
    }
}
//GetDataAndPrintToConsole("users");


void GetDataAndWriteToSeperateFile(List<User> userList)
{
    foreach (User user in userList)
    {
       FileStream fileStreamObject = new FileStream($@"C:\test\Users\{user.FirstName} {user.LastName}.txt", FileMode.Append);
       using (StreamWriter writeToUserFile = new StreamWriter(fileStreamObject))
       {
         writeToUserFile.Write($"{user.FirstName} {user.LastName} {user.YearOfBirth} {user.Email}\n");

       }
    }   
}

//GetDataAndWriteToSeperateFile(usersList);

void GetDataFromUserFile(string fileName)
{
    FileStream fileStreamObject = new FileStream($@"C:\test\Users\{fileName}.txt", FileMode.Open);
    using (StreamReader readFromUserFile = new StreamReader(fileStreamObject))
    {
        for (int i = 0; i < readFromUserFile.Peek(); i++)
        {
            Console.WriteLine(readFromUserFile.ReadLine());
        }
    }
}

//GetDataFromUserFile("bob kali");



void AddUser()
{
   Console.WriteLine("Please Enter firstName,lastName,yearOfBirth,eamil");
   usersList.Add(new User(Console.ReadLine(), Console.ReadLine(), int.Parse(Console.ReadLine()), Console.ReadLine()));
   foreach (User user in usersList)
   {
       Console.WriteLine($"{user.FirstName} {user.LastName} {user.YearOfBirth} {user.Email}");
   }
}

void DeleteUser(string fileName)
{
    File.Delete(fileName);
}

void EditUser(string userName)
{
    string[] arrayOfStrings;

    FileStream fileStreamObject = new FileStream($@"C:\test\Users\{userName}.txt", FileMode.Open);
    using (StreamReader readFromUserFile = new StreamReader(fileStreamObject))
    {
        arrayOfStrings = readFromUserFile.ReadLine().Split(" ");
    }

    FileStream userFile = new FileStream($@"C:\test\Users\{userName}.txt", FileMode.Create);
    using (StreamWriter writeToUserFile = new StreamWriter(userFile))
    {
        Console.WriteLine("Please Select The Options");
        Console.WriteLine("1. Edit firstName");
        Console.WriteLine("2. Edit lastName");
        Console.WriteLine("3. Edit yearOfBirth");
        Console.WriteLine("4. Edit email");
        int selectedOption = int.Parse(Console.ReadLine());
        switch (selectedOption)
        {
            case 1:
                Console.WriteLine("Enter firstName");
                Update(0, writeToUserFile, arrayOfStrings);
                break;
            case 2:
                Console.WriteLine("Enter lastName");
                Update(1, writeToUserFile, arrayOfStrings);
                break;
            case 3:
                Console.WriteLine("Enter yearOfBirth");
                Update(2, writeToUserFile, arrayOfStrings);
                break;
            case 4:
                Console.WriteLine("Enter Email");
                Update(3, writeToUserFile, arrayOfStrings);
                break;
            default:
                EditUser(userName);
                break;
        }
    }
}

void Update(int number, StreamWriter writeToFile, string[] array)
{
    switch (number)
    {
        case 0:
            writeToFile.Write($"{array[0] = Console.ReadLine()} {array[1]} {array[2]} {array[3]}");
            break;
        case 1:
            writeToFile.Write($"{array[0]} {array[1] = Console.ReadLine()} {array[2]} {array[3]}");
            break;
        case 2:
            writeToFile.Write($"{array[0]} {array[1]} {array[2] = Console.ReadLine()} {array[3]}");
            break;
        case 3:
            writeToFile.Write($"{array[0]} {array[1]} {array[2]} {array[3] = Console.ReadLine()}");
            break;
        default:
            Update(number,writeToFile,array);
            break;
    }
}