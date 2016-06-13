USE [matrix]
GO
/****** Object:  StoredProcedure [dbo].[full_matrix_get]    Script Date: 12.06.2016 15:04:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER proc [dbo].[full_matrix_get]
(
	@doc_id		int				
,	@group_id	varchar(max)	= null
,	@art		varchar(max)	= null
)
as

begin

	set nocount on


	;with	rest_and_needs
		as
	(
		select	isnull(csi.store_id, mi.store_id) as store_id
			,	isnull(csi.prod_id, mi.prod_id) as prod_id
			,	csi.qty
			,	csi.reserves
			,	csi.in_transit
			,	mi.doc_id
			,	mi.min_qty
			,	mi.priority
		from	(select * from dbo.current_store_items where store_id in (select store_id from dbo.stores))as csi
		full join
				(select * from dbo.matrix_items where doc_id = @doc_id and store_id in (select store_id from dbo.stores)) as mi 
				on mi.prod_id = csi.prod_id and mi.store_id = csi.store_id

	)
	select	p.prod_id
		,	p.group_id
		,	p.eng_name
		,	p.rus_name
		,	p.art
		,	rn.qty
		,	rn.store_id
		--,	s.store_name
		,	rn.min_qty
		,	rn.priority
		,	rn.doc_id
		,   rn.reserves
		,   rn.in_transit
		,   rn.qty as Expr1
		,	s.company_id
	
	from  dbo.viewmatrixprod as p
	left join
			rest_and_needs as rn on rn.prod_id = p.prod_id
	left join
			dbo.stores as s on s.store_id = rn.store_id
	where	(@art is null or p.art like @art)
			and (@group_id is null or p.group_id like @group_id) 

	
	return

end

