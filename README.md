# Mini Orders App

## Description

This is a simple purchase order management web application (Mini Orders App) built as part of a technical challenge. The application allows users to create, view, update, and delete orders through a user interface.

The project is divided into two parts: a backend built with .NET Core that exposes a RESTful API, and a frontend built with Vue.js 3 and TypeScript.

## Tech Stack

**Backend:**
* .NET 8 (with ASP.NET Core)
* Controller & Service Architecture
* RESTful API
* Swagger (OpenAPI) for interactive documentation
* xUnit for Unit Testing

**Frontend:**
* Vue.js 3
* Vite
* TypeScript
* Pinia (for global state management)
* Vue Router (for navigation)
* Zod (for client-side schema validation)
* Tailwind CSS

## Getting Started

Follow these instructions to run the project on your local machine.

### Prerequisites

Ensure you have the following installed:
* [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) or higher.
* [Node.js](https://nodejs.org/) (version 18+ recommended).

### Installation and Execution

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/eemenalop/mini-orders-app.git]
    cd mini-orders-app
    ```

2.  **Install Dependencies:**
    You need to install dependencies for both the root orchestrator and the frontend application.
    ```bash
    # Install root dependency (concurrently)
    npm install

    # Install frontend dependencies
    npm install --prefix frontend
    ```

3.  **Run the Application (Recommended Method):**
    From the **root directory**, run the following single command to start both the backend and frontend servers.
    ```bash
    npm run dev
    ```
    * The .NET API will start (typically on `http://localhost:5150/swagger/index.html`).
    * The Vue.js application will be available at `http://localhost:5173`.

4.  **Alternative Method (Two Terminals):**
    You can also run each project in a separate terminal.
    * **Terminal 1 (Backend):**
        ```bash
        cd backend
        dotnet run
        ```
    * **Terminal 2 (Frontend):**
        ```bash
        cd frontend
        npm run dev
        ```

## Architecture and Design Decisions

For this project, I made several decisions with the goal of demonstrating software development best practices:

* **Backend:**
    * **Controller & Service Architecture:** I separated the business logic (`OrderService`) from the API layer (`OrdersController`) to follow the Single Responsibility Principle and facilitate testing.
    * **DTOs (Data Transfer Objects):** I implemented DTOs (`CreateOrderDto`, `UpdateOrderDto`) to decouple the API contract from the internal domain model, improving security and flexibility.
    * **Unit Testing:** I added an xUnit project to test the `OrderService` logic, ensuring code quality and robustness.

* **Frontend:**
    * **Vue 3 with Composition API (`<script setup>`):** I chose Vue's modern approach to write more reusable code.
    * **Pinia for State Management:** I centralized all application state and API calls in a Pinia store. This keeps components clean of business logic and avoids "prop drilling".
    * **Zod for Validation:** I implemented client-side schema validation with Zod to provide instant feedback to the user and ensure invalid data is not sent to the API.

## Usage Examples

This section provides a quick visual tour of the Mini Orders App's key functionalities.

### 1. Viewing Existing Orders

Upon launching the application, you'll see a list of all current orders. This view includes options to create new orders, view details, and delete existing ones.

<img width="1041" height="815" alt="Screenshot 2025-10-05 at 2 33 45 PM" src="https://github.com/user-attachments/assets/fb87937e-74ba-42d2-8212-ca7f4bd96e9f" />

### 2. Creating a New Order

Clicking the "Create New Order" button navigates to a dedicated form. Here, you can input the customer's name and the total amount. Client-side validation is applied to ensure data integrity before submission.

<img width="763" height="484" alt="Screenshot 2025-10-05 at 2 34 54 PM" src="https://github.com/user-attachments/assets/65e8abcd-ad45-43cf-b0ef-6718368056a0" />
<img width="785" height="553" alt="Screenshot 2025-10-05 at 2 34 11 PM" src="https://github.com/user-attachments/assets/826bd12b-e39c-40c4-88ed-9a4f504d7e61" />
<img width="735" height="508" alt="Screenshot 2025-10-05 at 2 39 47 PM" src="https://github.com/user-attachments/assets/9637c16c-9065-457b-ae16-a3e0a841918c" />
<img width="1472" height="847" alt="Screenshot 2025-10-05 at 2 35 09 PM" src="https://github.com/user-attachments/assets/701114cb-fd7d-40b6-9dd6-8280e46012fa" />

### 3. Viewing Order Details

Clicking "View Details" on any order in the list will take you to a dedicated page showing more information about that specific order.

<img width="839" height="360" alt="Screenshot 2025-10-05 at 2 35 35 PM" src="https://github.com/user-attachments/assets/81e0f2a4-0f7d-4dec-8acb-11bcd2f6eae1" />


## Personal Reflection

A challenging aspect was dealing with the initial environment setup, particularly with the HTTPS configuration in .NET and inconsistencies with the `npm` package manager on my local machine. I resolved this by systematically investigating: first by diagnosing the missing .NET development certificate, and then, for the `npm`/`tailwindcss` issues, by opting to reinstall specific, compatible versions of the dependencies.

This process, though frustrating, reinforced the importance of a clean development environment and of understanding how build tools work under the hood.

Additionally, the biggest challenge for me was working with Vue.js, as I had never built anything with it before. I made sure to research its origins and purpose, as well as how it works. I found it to be somewhat similar to React, which gave me an advantage and made it straightforward to grasp the methodology.
