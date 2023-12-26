using System.Threading.Channels;

//Car car = new();
//(car as IMovable).Move();
//car.Move();

//IMovable objMove = new Car();
//objMove.Move();
//objMove = new Person();
//objMove.Move();

//DoMove(car);
//DoMove(new Person());


Car car2 = new Car();
IMovable car3 = car2;

car2.Move();
car3.Move();


Student student = new Student();
ISchool school = student;
IUniversitet universitet = student;

student.Study();
school.Study();
universitet.Study();


void DoMove(IMovable obj) => obj.Move();


interface IMovable
{
    // methods, properties, indexators, events, static fields and consts

    const int minSpeed = 0;
    static int maxSpeed = 200;
    void Move()
    {
        Console.WriteLine("Object move");
    }
    string Name { set; get; }

    delegate void MoveHandler(string message);
    event MoveHandler MoveEvent;
}

class Car : IMovable
{
    public string Name { get; set; }

    public event IMovable.MoveHandler MoveEvent;

    public void Move()
    {
        Console.WriteLine("Car move!");
    }

    void IMovable.Move() => Console.WriteLine("Object car move");
}

class Person : IMovable
{
    public string Name { get; set; }

    public event IMovable.MoveHandler MoveEvent;

    public void Move()
    {
        Console.WriteLine("Person move!");
    }
}

abstract class Transport : IMovable
{
    public abstract string Name { get; set; }

    public abstract event IMovable.MoveHandler MoveEvent;
}

class Ship : Transport, ISchool
{
    public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override event IMovable.MoveHandler MoveEvent;

    public void Study()
    {
        throw new NotImplementedException();
    }
}


interface ISchool
{
    void Study();
}

interface IUniversitet
{
    void Study();
}

class Student : ISchool, IUniversitet
{
    public void Study() => Console.WriteLine("Student study");
    void ISchool.Study() => Console.WriteLine("Student study in school");
    void IUniversitet.Study() => Console.WriteLine("Student study in universitet");
}