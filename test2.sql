declare @Customers table (
                           CustomerId int not null
						  ,RegistrationDateTime datetime not null 
						   PRIMARY KEY (CustomerId)
						   )
declare @Orders table (
                        CustomerId int not null
					   ,PurchaiseDatetime datetime not null
					   ,ProductName varchar(100)
					   )
insert into @Customers (CustomerId ,RegistrationDateTime) values (1,100116)
                                                                ,(2,110216)
                                                                ,(3,120316)
                                                                ,(4,010416)
insert into @Orders (CustomerId,PurchaiseDatetime,ProductName) values (1,current_timestamp,'milk')
                                                                     ,(1,current_timestamp,'sour cream')
																	 ,(2,current_timestamp,'milk')
																	 ,(2,current_timestamp,'sausage')
																	 ,(3,current_timestamp,'sausage')
																	 ,(3,current_timestamp,'sour cream')
																	 ,(4,current_timestamp,'milk')
																	 ,(4,current_timestamp,'milk')

select c.CustomerId,o.PurchaiseDatetime,o.ProductName 
       from @Customers c join 
	   @Orders o on o.CustomerId=c.CustomerId and 
	   o.CustomerId in (select CustomerId from @Orders where ProductName='milk') and  
	   o.CustomerId not in (select CustomerId from @Orders where ProductName='sour cream') and 
	   o.ProductName='milk' 
       group by c.CustomerId,o.PurchaiseDatetime,o.ProductName