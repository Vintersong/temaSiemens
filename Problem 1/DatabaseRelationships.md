# Coffee Shop Database Relationships (ER Diagram)

## Entity Relationship Diagram Documentation

### Tables and Relationships:

#### 1. **Shop** (Coffee Shop Locations)
- **Primary Key**: ShopID
- **Attributes**: ShopName, ShopAddress
- **Relationships**:
  - One Shop ? Many Baristas (1:N)
  - One Shop ? Many Orders (1:N)

---

#### 2. **Barista** (Employees)
- **Primary Key**: BaristaID
- **Foreign Keys**: ShopID ? Shop.ShopID
- **Attributes**: BaristaFirstName, BaristaLastName, EmploymentDate
- **Relationships**:
  - Many Baristas ? One Shop (N:1)
  - One Barista ? Many Orders (1:N) - tracks who prepared each order

---

#### 3. **MembershipType** (Loyalty Tiers)
- **Primary Key**: TierID
- **Attributes**: TierName (Regular/Gold), PointsMultiplier (1 or 2)
- **Relationships**:
  - One MembershipType ? Many Customers (1:N)

---

#### 4. **Customer** (Shop Customers)
- **Primary Key**: CustomerID
- **Foreign Keys**: TierID ? MembershipType.TierID
- **Attributes**: CustomerFirstName, CustomerLastName, RegistrationDate, LoyaltyPoints
- **Relationships**:
  - Many Customers ? One MembershipType (N:1)
  - One Customer ? Many Orders (1:N)
  - One Customer ? Many LoyaltyTransactions (1:N)

---

#### 5. **Beverage** (Coffee Types)
- **Primary Key**: BeverageID
- **Attributes**: BeverageName, BeverageDescription, BeverageType (Espresso/Latte/Cappuccino)
- **Relationships**:
  - One Beverage ? Many BeveragePrices (1:N)
  - One Beverage ? Many OrderItems (1:N)

---

#### 6. **Size** (Beverage Sizes)
- **Primary Key**: SizeID
- **Attributes**: SizeName (Small/Medium/Large)
- **Relationships**:
  - One Size ? Many BeveragePrices (1:N)
  - One Size ? Many OrderItems (1:N)

---

#### 7. **BeveragePrice** (Pricing Matrix - Junction Table)
- **Primary Key**: PriceID
- **Foreign Keys**: 
  - BeverageID ? Beverage.BeverageID
  - SizeID ? Size.SizeID
- **Attributes**: Price
- **Purpose**: Defines price for each Beverage-Size combination (M:N relationship)

---

#### 8. **Extra** (Add-ons/Customizations)
- **Primary Key**: ExtraID
- **Attributes**: ExtraName (extra shot/vanilla syrup/caramel syrup/whipped cream), ExtraPrice
- **Relationships**:
  - One Extra ? Many OrderItemExtras (1:N)

---

#### 9. **Order** (Customer Purchase)
- **Primary Key**: OrderID
- **Foreign Keys**: 
  - CustomerID ? Customer.CustomerID
  - BaristaID ? Barista.BaristaID
  - ShopID ? Shop.ShopID
- **Attributes**: OrderDate, FinalTotal
- **Relationships**:
  - Many Orders ? One Customer (N:1)
  - Many Orders ? One Barista (N:1)
  - Many Orders ? One Shop (N:1)
  - One Order ? Many OrderItems (1:N) - **Composition**
  - One Order ? Many LoyaltyTransactions (1:N)

---

#### 10. **OrderItem** (Individual Items in Order)
- **Primary Key**: OrderItemID
- **Foreign Keys**: 
  - OrderID ? Order.OrderID
  - BeverageID ? Beverage.BeverageID
  - SizeID ? Size.SizeID
- **Attributes**: Quantity, UnitPrice
- **Relationships**:
  - Many OrderItems ? One Order (N:1) - **Composition**
  - Many OrderItems ? One Beverage (N:1)
  - Many OrderItems ? One Size (N:1)
  - One OrderItem ? Many OrderItemExtras (1:N)

---

#### 11. **OrderItemExtra** (Extras Applied to Items - Junction Table)
- **Primary Key**: OrderItemExtraID
- **Foreign Keys**: 
  - OrderItemID ? OrderItem.OrderItemID
  - ExtraID ? Extra.ExtraID
- **Purpose**: Links extras to specific order items (M:N relationship)

---

#### 12. **LoyaltyTransaction** (Points Tracking)
- **Primary Key**: TransactionID
- **Foreign Keys**: 
  - CustomerID ? Customer.CustomerID
  - OrderID ? Order.OrderID
- **Attributes**: PointsEarned, PointsRedeemed, TransactionDate
- **Relationships**:
  - Many LoyaltyTransactions ? One Customer (N:1)
  - Many LoyaltyTransactions ? One Order (N:1)

---

## Cardinality Summary:

| Relationship | Cardinality | Type |
|--------------|-------------|------|
| Shop ? Barista | 1:N | One-to-Many |
| Shop ? Order | 1:N | One-to-Many |
| MembershipType ? Customer | 1:N | One-to-Many |
| Customer ? Order | 1:N | One-to-Many |
| Customer ? LoyaltyTransaction | 1:N | One-to-Many |
| Barista ? Order | 1:N | One-to-Many |
| Order ? OrderItem | 1:N | Composition |
| Order ? LoyaltyTransaction | 1:N | One-to-Many |
| Beverage ? OrderItem | 1:N | One-to-Many |
| Beverage ? BeveragePrice | 1:N | One-to-Many |
| Size ? OrderItem | 1:N | One-to-Many |
| Size ? BeveragePrice | 1:N | One-to-Many |
| OrderItem ? OrderItemExtra | 1:N | One-to-Many |
| Extra ? OrderItemExtra | 1:N | One-to-Many |
| Beverage ? Size (via BeveragePrice) | M:N | Many-to-Many |
| OrderItem ? Extra (via OrderItemExtra) | M:N | Many-to-Many |

---

## Key Design Patterns:

1. **Junction Tables** (for Many-to-Many):
   - `BeveragePrice`: Links Beverage and Size with pricing
   - `OrderItemExtra`: Links OrderItem and Extra for customizations

2. **Composition Relationship**:
   - Order **owns** OrderItems (if Order is deleted, OrderItems are deleted)

3. **Foreign Key Pattern**:
   - All relationships use ID-based foreign keys for database persistence
   - IDs are integers for optimal database performance

---

## Business Rules Implemented:

? **Beverages**: 3 types (Espresso, Latte, Cappuccino)
? **Sizes**: 3 sizes (Small, Medium, Large) with different prices per beverage
? **Extras**: Customizable add-ons with additional costs
? **Loyalty Program**: Regular (1x) and Gold (2x) point multipliers
? **Order Tracking**: Barista, timestamp, total price tracked per order
? **Multi-location**: Support for multiple coffee shop locations
