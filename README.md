<img width="1271" height="628" alt="image" src="https://github.com/user-attachments/assets/fd579af6-496e-40ca-afd9-f74ff037fbb6" />


<img width="1220" height="621" alt="image" src="https://github.com/user-attachments/assets/4593d9b7-efb8-4709-9a1b-ff2896f7dcab" />


<img width="1233" height="566" alt="image" src="https://github.com/user-attachments/assets/7eb13307-d80c-4063-9f03-b46ef88a832d" />

📚 **Library Management System**
This is a **Library Management System** project developed using **ASP.NET Core MVC (.NET 8)** with a layered architecture.

In this project, books can be managed together with their **author, category, and publisher** information.

🚀 **Technologies Used**
Backend: ASP.NET Core MVC (.NET 8)
ORM: Entity Framework Core
Database: SQLite
Frontend: HTML, CSS, JavaScript
Design: Bootstrap (Bootswatch – Lux Theme)

📊 **Database Structure**
The project consists of **4 main tables**:

* Books
* Authors
* Categories
* Publishers

🔗 **Relationships (1-M)**
Each book has:

* 1 author
* 1 category
* 1 publisher

One author, category, or publisher can be associated with multiple books.

**Data integrity** is ensured using **Foreign Key relationships**.

🛠️ **Features**
✔ Full CRUD operations (Create, List, Update, Delete)
✔ Total record counts displayed on the dashboard
✔ Secure data selection using dropdown lists
✔ Data integrity ensured with the Restrict delete rule
✔ BookVM usage (ViewModel structure)
✔ Layered and Clean Code architecture

🖼️ **Image Upload**
Book cover images can be uploaded.
Images are stored in the **wwwroot/images/books** folder.
File names are generated using **GUID** to prevent conflicts.

📌 **Dashboard**
Through the dashboard screen, the system can instantly display:

* Total Number of Books
* Total Number of Authors
* Total Number of Categories
* Total Number of Publishers

🧱 **Architecture**
The project uses the **MVC architecture**.
**Dependency Injection** is implemented.
The common layout design is centralized in **_Layout.cshtml**.
The code structure is clean and well organized.

🎯 **Project Purpose**
This project was created to **learn the ASP.NET Core MVC architecture, build a relational database structure using Entity Framework, and practically implement Full CRUD operations**.
