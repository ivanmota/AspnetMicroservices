# AspnetMicroservices

This project is part of my studies of Microservice Architecture. I am creating this code when I am doing the Udemy Course [Microservices Architecture and Implementation on .NET 5](https://www.udemy.com/course/microservices-architecture-and-implementation-on-dotnet/) by [Mehmet Özkaya](https://github.com/mehmetozkaya). You can find his original code on [run-aspnetcore-microservices](https://github.com/aspnetrun/run-aspnetcore-microservices) repository.

Some different aspects, compared with Mehmet Özkaya Repository:

- I'm coding with Visual Studio Community 2022 using .Net 6
- I've added the suffix "async" in async methods on repositories, services, etc.
- Instead of using Newtonsoft.Json package I'm using System.Text.Json;
- In the Ordering.Application for the classes with the suffix "Vm" (View Model) I changed the suffix to "Dto" (Data Transfere Object)
- On logger messages I avoid to use string interpolation
