 -- Agaesh Librarian (Id = 15) creates 2 borrow records
INSERT INTO Borrows (BookId, MemberId, BorrowDate, DueDate, ReturnDate, IsReturned, Quantity, FineAmount, CreateDate, UpdateDate, CreateById)
VALUES
(1, 16, GETDATE(), DATEADD(DAY, 14, GETDATE()), NULL, 0, 1, 0, GETDATE(), GETDATE(), 2), -- John Member borrows Clean Code
(2, 18, GETDATE(), DATEADD(DAY, 14, GETDATE()), NULL, 0, 1, 0, GETDATE(), GETDATE(), 2); -- Emily Member borrows Pragmatic Programmer

-- David Librarian (Id = 19) creates 2 borrow records
INSERT INTO Borrows (BookId, MemberId, BorrowDate, DueDate, ReturnDate, IsReturned, Quantity, FineAmount, CreateDate, UpdateDate, CreateById)
VALUES
(3, 20, GETDATE(), DATEADD(DAY, 14, GETDATE()), NULL, 0, 1, 0, GETDATE(), GETDATE(), 6), -- Michael Member borrows Design Patterns
(4, 23, GETDATE(), DATEADD(DAY, 14, GETDATE()), NULL, 0, 1, 0, GETDATE(), GETDATE(), 6); -- Olivia Member borrows Refactoring

-- Daniel Librarian (Id = 22) creates 2 borrow records
INSERT INTO Borrows (BookId, MemberId, BorrowDate, DueDate, ReturnDate, IsReturned, Quantity, FineAmount, CreateDate, UpdateDate, CreateById)
VALUES
(5, 16, GETDATE(), DATEADD(DAY, 14, GETDATE()), NULL, 0, 1, 0, GETDATE(), GETDATE(), 9), -- John Member borrows Domain-Driven Design
(6, 20, GETDATE(), DATEADD(DAY, 14, GETDATE()), NULL, 0, 1, 0, GETDATE(), GETDATE(), 9); -- Michael Member borrows Effective Java
