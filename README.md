# Siemens Internship Assignment 2026
## Dynamics & Azure / Full Stack

This repository contains the solutions to the two programming problems given as part of the **Siemens Dynamics & Azure / Full Stack Internship 2026** application.

---

## Repository Structure

```
temaSiemens/
├── Problem 1/          # Coffee shop class diagram + ER diagram + DB connection demo
│   ├── Beverage.cs
│   ├── BeveragePrices.cs
│   ├── Barista.cs
│   ├── Customer.cs
│   ├── Extra.cs
│   ├── LoyaltyTransaction.cs
│   ├── MembershipType.cs
│   ├── Order.cs
│   ├── OrderItem.cs
│   ├── OrderItemExtra.cs
│   ├── Shop.cs
│   ├── Size.cs
│   ├── Database Diagram.png # Visual representation of the database tables and their relationship.
│   ├── CoffeShopDiagram.cd      # Visual Studio class diagram (1.1)
│   ├── DatabaseRelationships.md # ER diagram documentation (1.2)
│   └── database/
│       └── coffeeShop.accdb     # Microsoft Access database
└── Problem 2/          # SieMarket order management classes + algorithms
    ├── Customer.cs
    ├── Item.cs
    └── Order.cs
```

---

## Problem 1 — Sarah's Coffee Shop (Class & ER Diagram)

### Domain Overview

Sarah runs a multi-location coffee shop chain. The system models:

- **Beverages** — Espresso, Latte, Cappuccino, each available in Small / Medium / Large.
- **Pricing** — Each Beverage + Size combination has its own price (`BeveragePrice`).
- **Extras** — Optional add-ons (extra espresso shot, vanilla syrup, caramel syrup, whipped cream) that each carry an additional cost applied directly to the order item.
- **Customers & Loyalty Program** — Customers are either Regular (1 point / €) or Gold (2 points / €) members. Points are earned on every purchase and can be redeemed for free drinks.
- **Orders** — Each order records the customer, the barista who prepared it, the shop location, the timestamp, and the line items with their chosen extras.
- **Multi-location** — The `Shop` class represents individual branch locations; baristas are assigned to a specific shop.

### 1.1 Class Diagram

The class diagram is provided as a Visual Studio `.cd` file (`CoffeShopDiagram.cd`).

**Key classes and relationships:**

| Class | Role |
|---|---|
| `Shop` | Coffee shop branch location |
| `Barista` | Employee; belongs to one Shop |
| `MembershipType` | Loyalty tier (Regular / Gold) |
| `Customer` | Loyalty-program member with a tier and a point balance |
| `BeverageType` (enum) | Espresso / Latte / Cappuccino |
| `Beverage` | Menu item (type + description, no price) |
| `Size` | Small / Medium / Large |
| `BeveragePrice` | Junction: price for a specific Beverage + Size combination |
| `Extra` | Optional add-on customization |
| `Order` | Purchase transaction (customer + barista + shop + timestamp) |
| `OrderItem` | One beverage line within an order (beverage + size + extras) |
| `OrderItemExtra` | DB junction linking OrderItem ↔ Extra |
| `LoyaltyTransaction` | Audit record of points earned / redeemed per order |

### 1.2 ER Diagram

The entity-relationship diagram is documented in [`DatabaseRelationships.md`](Problem%201/DatabaseRelationships.md), covering all 12 tables, their primary keys, foreign key relationships, junction tables, and cardinality.

A Microsoft Access database (`coffeeShop.accdb`) implements the schema.

## Problem 2 — SieMarket Online Electronics Store

### Domain Overview

SieMarket is a rapidly growing European electronics e-commerce platform that receives hundreds of orders daily.

### Classes

#### `Customer`
Represents a buyer. Properties: `CustomerID`, `FirstName`, `LastName`.
Method: `GetFullName()` — used by reporting methods to return a human-readable name.

#### `Item`
Represents a single product line within an order. Properties: `ProductName`, `Quantity`, `UnitPrice`.
`UnitPrice` uses `decimal` to avoid floating-point rounding errors on monetary values.

#### `Order`
Represents a customer order containing one or more items.

| Method | Requirement | Description |
|---|---|---|
| `CalculateFinalPrice()` | 2.2 | Sums all item totals; applies a **10% discount** when the subtotal exceeds **500 €**. |
| `FindTopSpender(List<Order>)` | 2.3 | Static method. Aggregates total spend per customer (after discounts) across all orders and returns the full name of the highest spender. |
| `GetPopularProducts(List<Order>)` | 2.4 *(Bonus)* | Static method. Aggregates total quantity sold per product across all orders and returns them sorted by quantity descending. |

### Discount Policy

> If the total value of an order exceeds **500 €**, the customer receives a **10% discount** on the entire order.

```csharp
if (subtotal > 500)
    return subtotal * 0.9m;
```

### Example Usage

```csharp
var customer1 = new Customer(1, "Ana", "Pop");
var customer2 = new Customer(2, "Ion", "Ionescu");

var order1 = new Order(1, customer1);
order1.Items.Add(new Item("Laptop", 1, 1200m));   // subtotal 1200 → 10% off → 1080

var order2 = new Order(2, customer2);
order2.Items.Add(new Item("Phone", 2, 300m));      // subtotal 600 → 10% off → 540
order2.Items.Add(new Item("Cable", 3, 10m));       // subtotal 630 → 10% off → 567

var allOrders = new List<Order> { order1, order2 };

Console.WriteLine(Order.FindTopSpender(allOrders));           // "Ana Pop"
var popular = Order.GetPopularProducts(allOrders);            // Cable:3, Phone:2, Laptop:1
```

---

## Technologies

| Technology | Usage |
|---|---|
| C# / .NET 9 | All class implementations |
| Microsoft Access (OLEDB) | Problem 1 database backend |
| Visual Studio | Class diagram (`.cd`), project structure |

---

## Author

Submitted as part of the **Siemens Dynamics & Azure / Full Stack Internship 2026** application process.
