using mveuCatchExc;


double a = 0;
try
{
    a = AriphmeticParse.Parse("12/0");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine(a);






