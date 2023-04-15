	
CREATE TABLE [dbo].[PHAN_QUYEN](
	[PQ_Ma] [varchar](10) NOT NULL,
	[PQ_Ten] [nvarchar](50) NULL,
	[PQ_MoTa] [nvarchar](100) NULL,
	[PQ_TinhTrang] [bit] NULL,
 CONSTRAINT [PK_PHAN_QUYEN] PRIMARY KEY CLUSTERED 
(
	[PQ_Ma] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NUOC_SAN_XUAT]    Script Date: 04/07/2023 21:10:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NUOC_SAN_XUAT](
	[NSX_Ma] [varchar](10) NOT NULL,
	[NSX_Ten] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[NSX_Ma] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHA_CUNG_CAP]    Script Date: 04/07/2023 21:10:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHA_CUNG_CAP](
	[NCC_Ma] [varchar](10) NOT NULL,
	[NCC_Ten] [nvarchar](50) NULL,
	[NCC_DiaChi] [nvarchar](100) NULL,
	[NCC_SDT] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[NCC_Ma] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOAI_HANG]    Script Date: 04/07/2023 21:10:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOAI_HANG](
	[LH_Ma] [varchar](10) NOT NULL,
	[LH_Ten] [nvarchar](50) NULL,
	[LH_MoTa] [nvarchar](100) NULL
PRIMARY KEY CLUSTERED 
(
	[LH_Ma] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KHACH_HANG]    Script Date: 04/07/2023 21:10:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHACH_HANG](
	[MA_KH] [varchar](10) NOT NULL,
	[TEN_KH] [nvarchar](20) NULL,
	[DIACHI] [nvarchar](100) NULL,
	[SDT] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MA_KH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HANGHOA]    Script Date: 04/07/2023 21:10:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HANGHOA](
	[HH_Ma] [varchar](10) NOT NULL,
	[LH_Ma] [varchar](10) NULL,
	[NSX_ma] [varchar](10) NULL,
	[NCC_ma] [varchar](10) NULL,
	[HH_Ten] [nvarchar](50) NULL,
	[HH_SoLuong] [int] NULL,
	[HH_MoTa] [nvarchar](100) NULL,
	[HH_DonGia] [float] NULL,
	[HH_HinhAnh] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[HH_Ma] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[InsertCustomers]    Script Date: 04/07/2023 21:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertCustomers]
    @makh VARCHAR(10),
    @tenkh nvarchar(20),
    @diachi nvarchar(100),
    @sdt varchar(10)

AS
BEGIN
    INSERT INTO KHACH_HANG
    VALUES (@makh, @tenkh, @diachi, @sdt)
END
GO
/****** Object:  StoredProcedure [dbo].[SearchCustomers]    Script Date: 04/07/2023 21:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SearchCustomers]
@ten NVARCHAR(50)
AS BEGIN
SELECT * FROM dbo.KHACH_HANG WHERE TEN_KH LIKE '%' + @ten + '%' or DIACHI like '%' + @ten + '%' or SDT like '%' + @ten + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[SearchCustomer]    Script Date: 04/07/2023 21:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SearchCustomer]
@ten NVARCHAR(50),
@diachi nvarchar(100),
@sdt varchar(10)
AS BEGIN
SELECT * FROM dbo.KHACH_HANG WHERE TEN_KH LIKE '%' + @ten + '%' or DIACHI like '%' + @ten + '%' or SDT like '%' + @ten + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomers]    Script Date: 04/07/2023 21:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCustomers]
    @makh VARCHAR(10),
    @tenkh nvarchar(20),
    @diachi nvarchar(100),
    @sdt varchar(10)

AS
BEGIN
    UPDATE KHACH_HANG
    SET  MA_KH = @makh, TEN_KH = @tenkh, DIACHI = @diachi, SDT = @sdt
    WHERE MA_KH = @makh
END
GO
/****** Object:  Table [dbo].[TAI_KHOAN_HE_THONG]    Script Date: 04/07/2023 21:10:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TAI_KHOAN_HE_THONG](
	[TKHT_Email] [varchar](30) NOT NULL,
	[TKHT_HoTen] [nvarchar](50) Null,
	[PQ_Ma] [varchar](10) NULL,
	[TKHT_Password] [varchar](20) NULL,
	[TKHT_DiaChi] [nvarchar](100) NULL,
	[TKHT_SoDienThoai] [varchar](10) NULL,
	[TKHT_GioiTinh] [bit] NULL,
	[TKHT_NgaySinh] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[TKHT_Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 04/07/2023 21:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateProduct]
    @mahang VARCHAR(10),
    @maloai VARCHAR(10),
    @manuocsx VARCHAR(10),
	@manhacungcap varchar(10),
    @tenhang nvarchar(50),
    @soluonghang int,
    @motahang nvarchar(100),
    @dongiahang float,
    @hinhanh varchar(max)
AS
BEGIN
    UPDATE HANGHOA
    SET LH_Ma = @maloai, NSX_ma = @manuocsx, NCC_Ma = @manhacungcap, HH_Ten =  @tenhang, HH_SoLuong = @soluonghang,  
    HH_MoTa = @motahang, HH_DonGia = @dongiahang, HH_HinhAnh = @hinhanh 
WHERE  HH_Ma = @mahang 
END
GO
/****** Object:  StoredProcedure [dbo].[SearchProduct]    Script Date: 04/07/2023 21:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SearchProduct]
@tenhanghoa NVARCHAR(50)
AS BEGIN
SELECT * FROM dbo.HANGHOA WHERE HH_Ten LIKE '%' + @tenhanghoa + '%' OR HH_DonGia LIKE '%' + @tenhanghoa + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[proc_login]    Script Date: 04/07/2023 21:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tao Prco 
CREATE PROC [dbo].[proc_login]
	@email varchar(30),
	@pass varchar(20),
	@roles int
as
BEGIN
	Select * from TAI_KHOAN_HE_THONG where TKHT_Email = @email AND TKHT_Password = @pass
END;
GO
/****** Object:  StoredProcedure [dbo].[proc_check_login]    Script Date: 04/07/2023 21:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_check_login]
	@email varchar(30),
	@pass varchar(20)
as
BEGIN
Select * from TAI_KHOAN_HE_THONG where TKHT_Email = @email AND TKHT_Password = @pass
END;
GO
/****** Object:  Table [dbo].[HOA_DON_XUAT]    Script Date: 04/07/2023 21:10:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOA_DON_XUAT](
	[HDX_Ma] [varchar](10) NOT NULL,
	[MA_KH] [varchar](10) NULL,
	[TKHT_Email] [varchar](30) NOT NULL,
	[HDX_NgayLap] [date] NULL,
	[HDX_TongTien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[HDX_Ma] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HOA_DON_NHAP]    Script Date: 04/07/2023 21:10:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOA_DON_NHAP](
	[HDN_Ma] [varchar](10) NOT NULL,
	[NCC_Ma] [varchar](10) NULL,
	[TKHT_Email] [varchar](30) NOT NULL,
	[HDN_NgayNhap] [date] NULL,
	[HDN_TongTien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[HDN_Ma] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ListOfProducts]    Script Date: 04/07/2023 21:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListOfProducts]
AS BEGIN
SELECT 
    HH.HH_Ma,
    LH.LH_Ten,
    NSX.NSX_Ten,
    NCC.NCC_Ten,
    HH.HH_Ten,
    HH.HH_SoLuong,
    HH.HH_MoTa,
    HH.HH_DonGia,
    HH.HH_HinhAnh
FROM [HANGHOA] AS HH
INNER JOIN [LOAI_HANG] AS LH ON HH.LH_Ma = LH.LH_Ma
INNER JOIN [NUOC_SAN_XUAT] AS NSX ON NSX.NSX_Ma =HH.NSX_Ma 
INNER JOIN [NHA_CUNG_CAP] AS NCC ON NCC.NCC_Ma = HH.NCC_Ma 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteofProduct]    Script Date: 04/07/2023 21:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteofProduct]
@mahang varchar(10)
AS BEGIN
DECLARE @kq BIT = 1
IF EXISTS(SELECT * FROM HANGHOA WHERE HH_Ma = @mahang)
	DELETE dbo.HANGHOA WHERE HH_Ma =  @mahang
ELSE
	SET @kq = 0
SELECT @kq
END
GO
/****** Object:  StoredProcedure [dbo].[InsertofProducts]    Script Date: 04/07/2023 21:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertofProducts]
    @mahang VARCHAR(10),
    @maloai VARCHAR(10),
    @manuocsx VARCHAR(10),
    @manhacungcap varchar(10),
    @tenhang nvarchar(50),
    @soluonghang int,
    @motahang nvarchar(100),
    @dongiahang float,
    @hinhanh varchar(max)

AS
BEGIN
    INSERT INTO HANGHOA
    VALUES (@mahang, @maloai, @manuocsx, @manhacungcap, @tenhang, @soluonghang, @motahang, @dongiahang, @hinhanh)
END
GO

/****** Object:  Table [dbo].[CHITIET_HD_NHAP]    Script Date: 04/07/2023 21:10:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHITIET_HD_NHAP](
	[HDN_Ma] [varchar](10) NOT NULL,
	[HH_Ma] [varchar](10) NOT NULL,
	[SoLuongNhap] [int] NULL,
	[DonGiaNhap] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[HDN_Ma] ASC,
	[HH_Ma] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHI_TIET_HD_XUAT]    Script Date: 04/07/2023 21:10:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHI_TIET_HD_XUAT](
	[HDX_Ma] [varchar](10) NOT NULL,
	[HH_Ma] [varchar](10) NOT NULL,
	[SoLuongXuat] [int] NULL,
	[DonGiaXuat] [float] NULL,
	[ThanhTien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[HDX_Ma] ASC,
	[HH_Ma] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE PROC [dbo].[ChangePassword]
@email NVARCHAR(50), @oldPassword NVARCHAR(50), @newPassword NVARCHAR(50)
AS BEGIN
DECLARE @password NVARCHAR(50), @result bit
SELECT @password = TKHT_Password FROM dbo.TAI_KHOAN_HE_THONG WHERE TKHT_Email = @email
IF @password = @oldPassword
BEGIN
    UPDATE dbo.TAI_KHOAN_HE_THONG SET TKHT_Password = @newPassword WHERE TKHT_Email = @email
	SET @result = 1
END
ELSE SET @result = 0
SELECT @result
END
GO
INSERT INTO [dbo].[HANGHOA] ([HH_Ma], [LH_Ma], [NSX_ma], [NCC_ma], [HH_Ten], [HH_SoLuong], [HH_MoTa], [HH_DonGia], [HH_HinhAnh])
VALUES
('HH_1', 'LH_1', 'NSX01', 'NCC01', N'Cát xây dựng Việt Nam', 12, N'Cát xây dựng Việt Nam tiêu chuẩn', 13000, NULL),
('HH_2', 'LH_2', 'NSX01', 'NCC02', N'Đá 1x2 Việt Nam', 12, N'Đá 1x2 Việt Nam chất lượng cao', 25000, NULL),
('HH_3', 'LH_2', 'NSX01', 'NCC03', N'Đá 1x2 Việt Nam', 12, N'Đá 1x2 Việt Nam tiêu chuẩn', 22000, NULL),
('HH_4', 'LH_3', 'NSX02', 'NCC03', N'Xi măng Hà Tiên', 12, N'Xi măng chất lượng cao', 80000, NULL),
('HH_5', 'LH_3', 'NSX02', 'NCC01', N'Gạch ống', 12, N'Tạo nên sự chắc chắn cho ngôi nhà bạn', 75000, NULL),
('HH_6', 'LH_1', 'NSX03', 'NCC03', N'Cát xây dựng Mỹ', 12, N'Cát xây dựng Mỹ chất lượng cao', 18000, NULL)
Go

Go
INSERT INTO TAI_KHOAN_HE_THONG (TKHT_Email,TKHT_HoTen , PQ_Ma, TKHT_Password, TKHT_DiaChi, TKHT_SoDienThoai, TKHT_GioiTinh, TKHT_NgaySinh)
VALUES ('toan@gmail.com',N'Đỗ Khánh Toàn', 'PQ01', '123456', 'Ha Noi', '0987654321', 1, '2000-01-01')
GO
INSERT INTO TAI_KHOAN_HE_THONG (TKHT_Email,TKHT_HoTen , PQ_Ma, TKHT_Password, TKHT_DiaChi, TKHT_SoDienThoai, TKHT_GioiTinh, TKHT_NgaySinh)
VALUES ('tin@gmail.com',N'Huỳnh Trung Tín', 'PQ01', '123456', 'Ha Noi', '0987654321', 1, '1990-01-01')
GO
INSERT INTO TAI_KHOAN_HE_THONG (TKHT_Email,TKHT_HoTen , PQ_Ma, TKHT_Password, TKHT_DiaChi, TKHT_SoDienThoai, TKHT_GioiTinh, TKHT_NgaySinh)
VALUES ('kiep@gmail.com','Trần Thanh Kiệp', 'PQ02', '123456', 'Ha Noi', '0987654321', 1, '1995-01-01')
GO
GO
INSERT INTO TAI_KHOAN_HE_THONG (TKHT_Email,TKHT_HoTen , PQ_Ma, TKHT_Password, TKHT_DiaChi, TKHT_SoDienThoai, TKHT_GioiTinh, TKHT_NgaySinh)
VALUES ('an@gmail.com',N'Nguyễn Thành An', 'PQ03', '123456', 'Ha Noi', '0987654321', 1, '1995-01-01')
GO
INSERT INTO TAI_KHOAN_HE_THONG (TKHT_Email,TKHT_HoTen , PQ_Ma, TKHT_Password, TKHT_DiaChi, TKHT_SoDienThoai, TKHT_GioiTinh, TKHT_NgaySinh)
VALUES ('1', 'An', 'PQ01', '1', 'Ha Tinh', '087654321', 0, '2002-01-01')
GO
GO
INSERT INTO PHAN_QUYEN (PQ_Ma, PQ_Ten, PQ_MoTa, PQ_TinhTrang)
VALUES ('PQ01', N'Quản trị viên', N'Quyền của quản trị viên', 1),
('PQ02', N'Chủ cửa hàng', N'Quyền của chủ cửa hàng', 1),
('PQ03', N'Nhân viên bán hàng', N'Quyền của nhân viên bán hàng', 1);
GO
INSERT INTO NHA_CUNG_CAP (NCC_Ma, NCC_Ten, NCC_DiaChi, NCC_SDT)
VALUES ('NCC01', N'Công ty TNHH A', N'123 Đường ABC, Quận 1, TP. HCM', '0123456789'),
('NCC02', N'Công ty TNHH B', N'456 Đường XYZ, Quận 2, TP. HCM', '0123456789'),
('NCC03', N'Công ty TNHH C', N'789 Đường LMN, Quận 3, TP. HCM', '0123456789');
GO
INSERT INTO LOAI_HANG (LH_Ma, LH_Ten, LH_MoTa)
VALUES ('LH_1', N'VẬT TƯ TIÊU CHUẨN PHẦN THÔ', N'Bao gồm các loại vật tư để xây dựng nên móng,...'),
('LH_2', N'SƠN NƯỚC', N'Bao gồm sơn nước, sơn khô, sơn xịt,...'),
('LH_3', N'LÁT NỀN', N'Bao gồm các loại gạch lát từ trong nhà ngoài sân,...'),
('LH_4', N'GẠCH ỐP TƯỜNG', N'Bao gồm các loại gạch đá,...'),
('LH_5', N'TRẦN THẠCH CAO', N'Bao gồm các loại thạch cao ốp trần nhà,...'),
('LH_6', N'CỔNG ', N'Gồm các loại cổng,...'),
('LH_7', N'CỬA ĐI', N'Gồm các loại cửa,...'),
('LH_8', N'THIẾT BỊ ĐIỆN VÀ CHIẾU SÁNG', N'Gồm có đèn, dây điện,...');
GO
INSERT INTO NUOC_SAN_XUAT (NSX_Ma, NSX_Ten)
VALUES ('NSX01', N'Việt Nam'),
('NSX02', N'Đức'),
('NSX03', N'Mỹ'),
('NSX04', N'Thái Lan'),
('NSX05', N'Trung Quốc');
GO
INSERT INTO KHACH_HANG (MA_KH, TEN_KH, DIACHI, SDT)
VALUES ('KH_1', N'Nguyễn Văn A', N'123 Đường ABC, Quận 1, TP. HCM', '0123456789'),
('KH_2', N'Trần Thị B', N'456 Đường XYZ, Quận 2, TP. HCM', '0123456789'),
('KH_3', N'Lê Văn C', N'789 Đường NVC, Quận 3, TP. HCM', '0123456789'),
('KH_4', N'Trần Thanh Kiệp', N'789 Đường NVL, Quận 5, TP. HCM', '0123456789'),
('KH_5', N'Đỗ Khánh Thòn', N'789 Đường NVC, Quận 9, TP. HCM', '0123456789'),
('KH_6', N'Huỳnh Trung Tín', N'789 Đường 3/2, Quận 10, TP. HCM', '0123456789'),
('KH_7', N'Nguyễn Thành Ân', N'789 Đường 30/4, Quận 1, TP. HCM', '0123456789');
GO

INSERT INTO [dbo].[HOA_DON_XUAT] ([HDX_Ma], [MA_KH], [TKHT_Email], [HDX_NgayLap], [HDX_TongTien])
VALUES ('HDX_1', 'KH_1', 'admin@localhost.com', '2023-04-01', 0)
GO


