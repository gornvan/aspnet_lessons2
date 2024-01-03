Console.WriteLine("Type something!");
    
var input = Console.ReadLine();
if(input == "bug"){
    while (true) {
        await Task.Delay(1000);
        Console.WriteLine("I'm broken!");   
    }
}
