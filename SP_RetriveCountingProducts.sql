CREATE PROCEDURE [dbo].[SP_RetriveCountingProducts]
AS
	SELECT barcode,
		SUM(jumlah)jumlah,
		SUM(total_harga)total_harga,
		SUM(ready)ready,
		SUM(onhold)onhold,
		SUM(delivered)delivered,
		SUM(packing)packing,
		SUM(sent)sent
	FROM (
		  SELECT barcode,COUNT(barcode)jumlah,sum(Price)total_harga,
			(SELECT CASE WHEN Status='READY' THEN COUNT(STATUS) ELSE 0 END) AS ready,
			(SELECT CASE WHEN Status='ONHOLD' THEN COUNT(STATUS) ELSE 0 END) AS onhold,
			(SELECT CASE WHEN Status='DELIVERED' THEN COUNT(STATUS) ELSE 0 END) AS delivered,
			(SELECT CASE WHEN Status='PACKING' THEN COUNT(STATUS) ELSE 0 END) AS packing,
			(SELECT CASE WHEN Status='SENT' THEN COUNT(STATUS) ELSE 0 END) AS sent
		  FROM dbo.Product
		  GROUP BY barcode,STATUS
     )ShowingReport 
	  GROUP BY barcode

RETURN 0
