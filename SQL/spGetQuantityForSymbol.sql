USE [FinanceS24]
GO
/****** Object:  StoredProcedure [dbo].[spGetQuantityForSymbol]    Script Date: 5/27/2024 12:15:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spGetQuantityForSymbol] 
	-- Add the parameters for the stored procedure here
	@ticker varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Transaction_ID AS ID, Date AS Dates, Price AS Prices, Quantity AS Quantities
	FROM Transactions
	WHERE Ticker = @ticker
END
