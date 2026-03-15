double getSideOfCube(double volume)
{
    return Math.Pow(volume, 1.0 / 3);
}
bool is_sum_uneven(int number)
{
    if (number > 100) { 
        Console.WriteLine("Number is not 2-digit.");
        return false;
    }
    int sum_of_digits = (number % 10) + ((number - number % 10)/10);
    return sum_of_digits % 2 != 0;
}

void is_in_triangle(double x, double y)
{
    double abs_x = Math.Abs(x);
    double upper_boundary = -abs_x;
    double lower_boundary = -100;

    bool on_upper = (y == upper_boundary) && (y >= lower_boundary);
    bool on_lower = (y == lower_boundary) && (abs_x <= 100);

    if (on_upper || on_lower)
    {
        Console.WriteLine("On the bounds");
    }

    else if (y < upper_boundary && y > lower_boundary)
    {
        Console.WriteLine("Inside of bounds");
    }
    else
    {
        Console.WriteLine("Outside of bounds");
    }
}
DateTime get_date(int n) { 
    if (n < 0) {
        Console.WriteLine("n must be non-negative.");
        return DateTime.Now;
    }
    DateTime current_date = DateTime.Now;
    return current_date.AddDays(-n);
}

int get_square_sum(int a, int b) { 
    return (a+b)*(a+b);
}

double get_result(double a, double b) {
    return 5 + b / (b * b + 1) + (a - b) / (a + b);
}

while (true)
{
    Console.WriteLine("Input task: ");
    int task = int.Parse(Console.ReadLine()!);

    switch (task)
    {
        case 1:
            Console.WriteLine("Task 1: Calculate side of cube from volume.");
            
            Console.WriteLine("Input volume of cube: ");
            double volume = double.Parse(Console.ReadLine()!);

            double side = getSideOfCube(volume);
            Console.WriteLine($"Side of the cube: {Math.Round(side)}");
            
            break;
        
        case 2:
            Console.WriteLine("Task 2: Check if sum of digits is uneven.");

            Console.WriteLine("Input 2-digit number: ");
            int number = int.Parse(Console.ReadLine()!);

            if (is_sum_uneven(number))
            {
                Console.WriteLine("Sum of digits is uneven.");
            } 
            else
            {
                Console.WriteLine("Sum of digits is even.");
            }
            
            break;
        
        case 3:
            Console.WriteLine("Task 3: Check if point is inside the triangle.");
            
            Console.WriteLine("Input x: ");
            double x = double.Parse(Console.ReadLine()!);
            
            Console.WriteLine("Input y: ");
            double y = double.Parse(Console.ReadLine()!);
            
            is_in_triangle(x, y);
            
            break;
        
        case 4:
            Console.WriteLine("Task 4: Get date n days ago.");

            Console.WriteLine("Input n: ");
            int n = int.Parse(Console.ReadLine()!);

            DateTime date = get_date(n);
            Console.WriteLine($"Date {n} days ago: {date.ToShortDateString()}");
            
            break;
        
        case 5:
            Console.WriteLine("Task 5: Get sum of squares of two numbers.");

            Console.WriteLine("Input a: ");
            int a = int.Parse(Console.ReadLine()!);
            
            Console.WriteLine("Input b: ");
            int b = int.Parse(Console.ReadLine()!);
            
            int square_sum = get_square_sum(a, b);
            Console.WriteLine($"Square of sum: {square_sum}");
            
            break;
        
        case 6:
            Console.WriteLine("Task 6: Get result of the expression.");
            
            Console.WriteLine("Input a: ");
            double a_double = double.Parse(Console.ReadLine()!);
            
            Console.WriteLine("Input b: ");
            double b_double = double.Parse(Console.ReadLine()!);
            
            double result = get_result(a_double, b_double);
            Console.WriteLine($"Result: {result}");
            
            break;
        
        default:
            Console.WriteLine("Invalid task number.");
            return;
    }
}
