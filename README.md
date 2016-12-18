# EntityFrameworkCore.GenericRepository

This is a simple implementation of a generic repository class that accepts a DbContext in constructor, and supports basic CRUD operations on model classes.

To use the generice repository, you must inherit from the included BaseEntity class, which allows the repository class to support any class via Generics.

For usage, see the test case examples, which use the EF Core in memory database to do basic operations.

The dll is currentlly targeting .net standard 1.6.

