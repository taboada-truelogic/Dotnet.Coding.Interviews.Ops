![Truelogic](tl.png)

# Order Processing System (OPS)

## Overview

The **Order Processing System** is a simple yet effective application designed to manage the lifecycle of orders, including order creation, inventory management, and payment processing. Built using .NET and C#, this application demonstrates the principles of clean architecture and dependency injection, showcasing a modular approach to service design.

## Purpose

The primary goal of the Order Processing System is to provide a clear and functional interface for managing orders in a retail or e-commerce context. It allows users to create, retrieve, update, and delete orders, while also ensuring that inventory levels are checked before order creation and payments are processed.

## Main Components

### 1. **Models**

- **Order**: Represents an order placed by a customer, including properties like `Id`, `InventoryId`, `Quantity`, and `IsPaid`.
- **Inventory**: Represents product inventory, including `Stock` to track available quantities.
- **Payment**: Represents a payment transaction related to an order, including `PaymentId`, `OrderId`, `Amount`, and `IsSuccessful`.

### 2. **Services**

- **IOrderService**: Interface for managing orders, providing methods for creating, retrieving, and updating orders.
- **IInventoryService**: Interface for checking stock availability and reducing stock when orders are placed.
- **IPaymentService**: Interface for processing payments associated with orders.

### 3. **Repositories**

- **IOrderRepository**: Interface for data access related to orders, including CRUD operations.
- **IInventoryRepository**: Interface for data access related to inventory management.
- **IPaymentRepository**: Interface for data access related to payment processing.

### 4. **Database Context**

- **OpsDbContext**: Entity Framework Core database context that manages the connection to the in-memory SQLite database and provides access to the application's data models.

### 5. **Controllers**

- **OrdersController**: ASP.NET Core controller that exposes RESTful endpoints for managing orders. It integrates the services to handle order processing, including inventory checks and payment processing.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- A code editor (e.g. [Visual Studio Code](https://code.visualstudio.com/))
