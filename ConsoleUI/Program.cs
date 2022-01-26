using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    // SOLID
    // open Closed principle
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetailDtos())
            {
                Console.WriteLine(car.CarName + " / " + car.ColorName + " / " + car.DailyPrice );
            }

            //CarManager carManager = new CarManager(new InMemoryCarDal());

            //foreach(var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}
        }
    }
}