USE [FinanceS24]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllDatesAndCloseForSymbol]    Script Date: 5/27/2024 12:13:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spGetAllDatesAndCloseForSymbol]
	-- Add the parameters for the stored procedure here
	@ticker varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TS_DailyData.Date AS Dates, "Close" AS "ClosingPrice"
	FROM TS_DailyData
	WHERE Ticker = @ticker
END

