Drop table Transactions

CREATE TABLE [dbo].[Transactions]
(
	[Transaction_ID] [int]          NOT NULL IDENTITY(1,1),
	[Ticker]    	[varchar](10)   NOT NULL,
	[Date]      	[datetime] 		NOT NULL,
	[Price]     	[money]         NOT NULL,
	[Quantity]  	[float]         NOT NULL,
	[Counterparty]  [varchar](10)   NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([Transaction_ID] ASC),
	CONSTRAINT [UK_Transactions] UNIQUE ([Ticker], [Date])
)  

GO

INSERT Transactions Values ('IBM', '2024-01-05 12:00:05', 122.20, 100,  'Watson')
INSERT Transactions Values ('IBM', '2024-01-07 13:00:06', 122.30, 100,  'Silver')
INSERT Transactions Values ('IBM', '2024-01-13',          120.60, 100,  'Watson')
INSERT Transactions Values ('IBM', '2024-01-23',          129.20, -1000, 'Watson')
INSERT Transactions Values ('GLD', '2024-01-22',          154.25, 2000,  'John Galt')
INSERT Transactions Values ('GSPC', '2024-01-28',        3710.10, -1000, 'Goldman')
INSERT Transactions Values ('AAPL', '2024-01-09',         151.00, 1000,  'Watson')
INSERT Transactions Values ('ZM', '2024-01-14',            67.20, 3000,  'Fiver')
INSERT Transactions Values ('ZM', '2024-01-16',            66.00, -3000, 'Watson')
/*
INSERT Transactions Values ('IBM', '2023-09-28 12:00:05', 122.20, 1000,  'Watson')
INSERT Transactions Values ('IBM', '2023-09-28 13:00:06', 122.30, 1000,  'Silver')
INSERT Transactions Values ('IBM', '2023-09-29',          120.60, 1000,  'Watson')
INSERT Transactions Values ('IBM', '2023-10-23',          129.20, -1000, 'Watson')
INSERT Transactions Values ('GLD', '2023-09-22',          154.25, 2000,  'John Galt')
INSERT Transactions Values ('GSPC', '2023-09-28',        3710.10, -1000, 'Goldman')
INSERT Transactions Values ('AAPL', '2023-10-09',         151.00, 1000,  'Watson')
INSERT Transactions Values ('ZM', '2023-08-14',            67.20, 3000,  'Fiver')
INSERT Transactions Values ('ZM', '2023-08-16',            66.00, -3000, 'Watson') */

SELECT *
FROM TS_DailyData