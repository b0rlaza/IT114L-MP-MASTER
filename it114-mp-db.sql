create table
[dbo].[UserAccountTBL](
[user_id] [int] not null,
[username] [nvarchar](20) not null,
[first_name] [nvarchar](50) not null,
[last_name] [nvarchar](50) not null,
[password] [nvarchar](100) not null,
[date_created] [date] not null,
[address] [nvarchar](200) null,
[contact_no] [varchar](20) null,
[user_level] [varchar](20) not null,
[access_status] [varchar](20) not null)

create table
[dbo].[ProductTBL](
[product_id] [int] not null,
[name] [nvarchar](100) not null,
[description] [nvarchar](255) null,
[price] [decimal](10,2) not null,
[image_loc] [nvarchar](255) null,
[qty_stock] [int] not null,
[qty_sold] [int] not null,
[status] [varchar](30) not null)

create table
[dbo].[ProductSalesTBL](
[transaction_id] [int] not null,
[user_id] [int] null,
[delivery_id] [int] not null,
[product_id] [int] not null,
[quantity] [int] not null,
[payment_status] [varchar](30) not null,
[total_invoice] [decimal](10,2) not null,
[transaction_date] [date] not null)

create table
[dbo].[DeliveryTBL](
[delivery_id] [int] not null,
[transaction_id] [int] not null,
[user_id] [int] null,
[type] [varchar](20) not null,
[name] [nvarchar](50) not null,
[contact] [varchar](20) not null,
[address] [nvarchar](150) not null,
[status] [varchar](20) not null,
[estimate_arrival] [date] not null)

insert into UserAccountTBL values(1, 'admin', 'General', 'Administrator', 'BcPpiXjm+AxXnboNxwuUs5+yIHZxEwaJesFBsyN4k/c=', '2022-02-22', '', '', 'Administrator', 'Allowed');