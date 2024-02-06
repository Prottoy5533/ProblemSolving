// See https://aka.ms/new-console-template for more information
using CodingPractice;

Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
var class1 = new Class1();
//char[] p = { 'h','e','l','l','o' };
//int[] x = { -7, -3, 2, 3, 11 };
//int[] nums = { 3, 1, 2, 7, 4, 2, 1, 1, 5 };
//int[] y = { 10, 5, 2, 6 };
//int[] z = { 3,-1,4,12,-5,5,6 };
//int[] maxSubArray = { 1, 12, -5, -6, 50, 3 };
//int[] maxConsOne = { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 };
//class1.findBestSubarray(z, 4);
//class1.findMaxAvgSubarray(maxSubArray, 4);
//class1.findMaxNumofOne(maxConsOne, 2);
//class1.ReverseString(p);
//class1.findLength(nums,8);
//class1.findLength("1101100111");
//class1.numSubarrayProductLessThanK(y,100);
//var sortedArray = class1.SortedSquares(x);
//Console.WriteLine(sortedArray); 
//int[] x = { 5,2,7,10,3,9, };

//var arr =  class1.TwoSum(8, x);

//foreach(var y in arr)
//{
//    Console.WriteLine(y);
//}


//var duplicateelement = class1.FirstLettertoAppearTwice("abcdeda");
//Console.WriteLine(duplicateelement);

//var checkPangram = class1.CheckIfPangram("leetcode");


//int[] nums = { 9, 6, 4, 2, 3, 5, 7, 0, 1 };

//var missingNum = class1.MissingNumber(nums);


//int[] arr = { 1, 2, 3};
//var countElements = class1.CountElements(arr);

//int[] notes = { 1000,500,200,100,50,20,10,5,2,1 };

//var amountCalculate = class1.CalculateAmount(notes, 1503);

//foreach (var item in amountCalculate)
//{
//    Console.WriteLine(item.Key + ": " + item.Value);

//}

//Console.WriteLine(countElements);

//var x = class1.areOccurrencesEqual("ababa");
//Console.WriteLine(x);

//int[][] matches = new int[][]
//    {
//        new int[] {1, 3},
//        new int[] {2, 3},
//        new int[] {3, 6},
//        new int[] {5, 6},
//        new int[] {5, 7},
//        new int[] {4, 5},
//        new int[] {4, 8},
//        new int[] {4, 9},
//        new int[] {10, 4},
//        new int[] {10, 9}
//    };

//class1.FindWinners(matches);
//int [] x= new int[] { 9,9,8,8 };

//Console.WriteLine(class1.LargestUniqueNumber(x));
//Console.WriteLine(class1.MaxNumberOfBalloons("nlaebobko"));
//string [] s = { "eat", "tea", "tan", "ate", "nat", "bat" };
//class1.groupAnagrams(s);

//var cards = new int[] { 3,4,2,3,4,7 };
//Console.WriteLine(class1.minimumCardPickup(cards));
//Console.WriteLine(class1.CanConstruct("aa","ab"));
//Console.WriteLine(class1.NumJewelsInStones("z", "ZZ"));
//Console.WriteLine(class1.validParanthesis("({)}"));
var home = new Home();

//Console.WriteLine(class1.RemoveDuplicates("abbaca"));
//Console.WriteLine(class1.backspaceCompare("a##c", "#a#c"));
//Console.WriteLine(class1.MakeGood("abBAcC"));


//var operation = new Operation();
//List<Employee> employees = Employee.GetEmployees();
//List<Salary> salaries = Salary.GetSalaries();

//operation.PrintEmploueeSalary(employees, salaries);

//var bicycle = new BiCycle();
//bicycle.EngineModel();

char[] p = { 'h', 'e', 'l', 'l', 'o' };

//int[] numbers = { 1, 2, 3, 4, 5, 6, 3, 4 };

//var x = numbers.OrderByDescending(x => x).Skip(1).FirstOrDefault();

//class1.reverseString(p);
//var ans = class1.IsPalindrome(121);
//Console.WriteLine(ans);

B bObj = new B();

int[] numbers = { 2, 0, 0 };

var numberTheory = new NumberTheory();
var dp = new DynamicProgramming();

numberTheory.SuperPow(2147483647, numbers);
//numberTheory.FindPrimes(10000);
//dp.ClimbStairs(5);

var office = new Office();

office.ReverseInt(12345);

int[] sticks = { 1, 8, 3, 5 };

//var sumSticks = office.ConnectSticks(sticks);
//Console.WriteLine(sumSticks);

//int[] nums = { 3, 6, 1, 2, 5 };
//office.PartitionArray(nums,2);

//int[] sortNums = { 3, 7, 5, 5, 3, 8 };
//office.CustomSortArray(sortNums, 3);

var graph = new Graph();

int[][] edges = {
            new int[] {4, 3},
            new int[] {1, 4},
            new int[] {4, 8},
            new int[] {1, 7},
            new int[] {6, 4},
            new int[] {4, 2},
            new int[] {7, 4},
            new int[] {4, 0},
            new int[] {0, 9},
            new int[] {5, 4}
        };

//graph.BuildGraph(edges);

var validPath = graph.ValidPath(10, edges, 5, 9);

//var list = new DoubleLinkedList();
//list.insertFirst(3);
//list.insertFirst(2);
//list.insertFirst(8);
//list.insertFirst(17);
//list.insertLast(1);
//list.insertIndex(6, 3);
//list.insertAfter(44, 17);
//list.insertAfter(45, 7);

//list.display();
//list.displayReverse();

var cllist = new CircularLinkedList();
cllist.insert(4);
cllist.insert(5);
cllist.insert(6);
cllist.insert(2);
cllist.delete(5);

//cllist.display();

//var a = new A();

int expiryLimit = 4;
List<List<int>> commands = new List<List<int>>
        {
            new List<int> {0, 1, 1},
            new List<int> {0, 2, 2},
            new List<int> {1, 1, 5},
            new List<int> {1, 2, 7}
        };

int result = A.numberOfTokens(expiryLimit, commands);

var company = new Company();
var laptop = new Product(1, "Laptop", 20, 5);
var phone = new Product(2, "Phone", 30, 3);

var user1 = new User(1, "User1", 100);

company.AddProduct(laptop, 20);
company.AddProduct(phone, 10);
company.AddProduct(laptop, 10);

company.AddUser(user1);

var userOrder = new List<(IProduct, int)>
        {
            (laptop, 3),
            (phone, 1)
        };

company.MakeOrder(userOrder, user1);

var arrayProblem = new ArrayProblem();
int[] arrayRotate = { 1, 2, 3, 4, 5, 6, 7 };

arrayProblem.Rotate(arrayRotate, 3);
arrayProblem.RotateAnotherApproach(arrayRotate, 3);

int[] num1 = { 1, 2, 2, 1 };
int[] num2 = { 2, 2, };
//int[] nums = { 0, 1, 0, 3, 12 };

arrayProblem.Intersect(num1, num2);
//arrayProblem.MoveZeroes(nums);

int[] nums = { 3, 2, 4 };
arrayProblem.TwoSum(nums, 6);
int[] arr = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };

var array = new ArrayProblem();
array.RemoveDuplicates(arr);

int[] plusOne = { 0 };
array.PlusOne(plusOne);

var stringProblem = new StringProblem();
stringProblem.Reverse(120);
stringProblem.IsAnagram("anagram", "nagaram");
stringProblem.IsPalindrome("A man, a plan, a canal: Panama");
stringProblem.StrStr("mississippi", "issipi");

var binarySearch = new BinarySearch();

int[] nums1 = { 2, 3, 5, 9, 14, 16, 18 };
binarySearch.SearchInsertCeil(nums1, 7);
binarySearch.SearchInsertFloor(nums1, 1);
binarySearch.ans(nums1, 9);


Console.ReadLine();

