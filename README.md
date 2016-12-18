# EntityFrameworkCore.GenericRepository

<img src="https://kmkatsma.visualstudio.com/_apis/public/build/definitions/95704f04-ee5a-42d1-918b-9b8ad69f02e0/3/badge"/>

This is a simple implementation of a generic repository class that accepts a DbContext in constructor, and supports basic CRUD operations on model classes.

To use the generic repository, you must inherit from the included BaseEntity class, which allows the repository class to support any class via Generics.

For usage, see the test case examples in RepositoryTests.cs, which use the EF Core in memory database to do basic operations.

The Generic Repository class currently supports Add, Update, Delete, and FindByID, and allows to optionally trigger SaveChanges.  All methods use async implementation.

The dll is currentlly targeting .net standard 1.6.

