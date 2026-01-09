# 🛒 Store API - Backend System

A robust and scalable RESTful API built to power an E-commerce platform. This system handles complex business logic, user authentication, and inventory management.

## 🚀 Key Features

- **Authentication & Authorization:** Secure user registration and login using **JWT (JSON Web Tokens)** and password hashing with **Bcrypt**.
- **Product Management:** Full CRUD operations for products, categories, and inventory tracking.
- **User Roles:** Role-based access control (RBAC) to distinguish between **Admins** and **Customers**.
- **Order Processing:** Logic for placing orders, calculating totals, and managing order status.
- **Security:** Implemented security headers, CORS configuration, and input validation to prevent SQL Injection/NoSQL Injection.
- **Error Handling:** Centralized global error handling middleware for consistent API responses.

## 🛠 Tech Stack

- **Runtime:** Node.js
- **Framework:** Express.js
- **Database:** [E.g., MongoDB with Mongoose / PostgreSQL with Sequelize or Prisma]
- **Authentication:** JWT (JSON Web Tokens)
- **Validation:** [E.g., Joi / Express-validator]
- **Documentation:** [E.g., Swagger / Postman Collection]

## 🏗 Database Schema
The system architecture is based on the following main entities:
- **Users:** Roles, credentials, and profiles.
- **Products:** Pricing, descriptions, stock levels, and categories.
- **Orders:** Linking users to multiple products with quantity and timestamps.

## 🔌 API Endpoints (Brief)

### Auth
- `POST /api/auth/register` - Create a new account.
- `POST /api/auth/login` - Authenticate user and return token.

### Products
- `GET /api/products` - List all products (with pagination/filtering).
- `POST /api/products` - Add new product (Admin Only).

### Orders
- `POST /api/orders` - Checkout and create a new order.
- `GET /api/orders/me` - Get logged-in user's order history.

## ⚙️ Installation

1. **Clone the repo:**
   ```bash
   git clone [https://github.com/Mo7sensaber/Store.git](https://github.com/Mo7sensaber/Store.git)

```

2. **Install dependencies:**
```bash
npm install

```


3. **Environment Variables:**
Create a `.env` file and add:
```env
PORT=5000
DATABASE_URL=your_connection_string
JWT_SECRET=your_secret_key

```


4. **Run the server:**
```bash
npm run dev

```



## 🛠 Architecture

This project follows the **MVC (Model-View-Controller)** pattern / **Clean Architecture** (choose yours) to ensure separation of concerns and maintainability.

---

## 👨‍💻 Author

**Mohsen Saber**

* [LinkedIn](https://www.linkedin.com/in/mohsen-saber-4b04bb259)
* [Portfolio](https://github.com/Mo7sensaber)

