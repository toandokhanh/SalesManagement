CREATE TABLE [dbo].[PHAN_QUYEN](
    [PQ_Ma] [varchar](5) NOT NULL,
    [PQ_Ten] [nvarchar](50) NULL,
    [PQ_MoTa] [nvarchar](100) NULL,
    [PQ_TinhTrang] [bit] NULL,
    CONSTRAINT [PK_PHAN_QUYEN] PRIMARY KEY CLUSTERED (
        [PQ_Ma] ASC
    ) WITH (
        PAD_INDEX = OFF, 
        STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, 
        ALLOW_ROW_LOCKS = ON, 
        ALLOW_PAGE_LOCKS = ON, 
        OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
    ) ON [PRIMARY]
) ON [PRIMARY];


GO
CREATE TABLE [dbo].[NHA_CUNG_CAP](
	[NCC_Ma] [varchar](5) NOT NULL,
	[NCC_Ten] [nvarchar](50) NULL,
	[NCC_DiaChi] [nvarchar](100) NULL,
	[NCC_SDT] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[NCC_Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

GO
CREATE TABLE LOAI_HANG (
    LH_Ma varchar(5) NOT NULL,
    LH_Ten nvarchar(20) NULL,
    LH_MoTa nvarchar(100) NULL,
    LH_TrangThai bit NULL,
    PRIMARY KEY CLUSTERED (LH_Ma ASC)
) ON [PRIMARY];
GO




GO
CREATE TABLE [dbo].[NUOC_SAN_XUAT](
	[NSX_Ma] [varchar](6) NOT NULL,
	[NSX_Ten] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[NSX_Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO


GO
CREATE TABLE [dbo].[KHACH_HANG](
	[MA_KH] [varchar](5) NOT NULL,
	[TEN_KH] [nvarchar](20) NULL,
	[DIACHI] [nvarchar](100) NULL,
	[SDT] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MA_KH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



GO
CREATE TABLE [dbo].[TAI_KHOAN_HE_THONG](
	[TKHT_Email] [varchar](30) NOT NULL,
	[PQ_Ma] [varchar](5) NULL,
	[TKHT_Password] [varchar](20) NULL,
	[TKHT_DiaChi] [nvarchar](100) NULL,
	[TKHT_SoDienThoai] [varchar](10) NULL,
	[TKHT_GioiTinh] [bit] NULL,
	[TKHT_NgaySinh] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[TKHT_Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




GO
CREATE TABLE [dbo].[HOA_DON_XUAT](
	[HDX_Ma] [varchar](5) NOT NULL,
	[MA_KH] [varchar](5) NULL,
	[TKHT_Email] [varchar](30) NOT NULL,
	[HDX_NgayLap] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[HDX_Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]


GO
CREATE TABLE [dbo].[HOA_DON_NHAP](
	[HDN_Ma] [varchar](5) NOT NULL,
	[NCC_Ma] [varchar](5) NULL,
	[TKHT_Email] [varchar](30) NOT NULL,
	[HDN_NgayNhap] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[HDN_Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


GO
CREATE TABLE [dbo].[HANGHOA](
	[HH_Ma] [varchar](5) NOT NULL,
	[LH_Ma] [varchar](5) NULL,
	[NSX_ma] [varchar](6) NULL,
	[NCC_ma] [varchar](5) NULL,
	[HH_Ten] [nvarchar](50) NULL,
	[HH_SoLuong] [int] NULL,
	[HH_MoTa] [nvarchar](100) NULL,
	[HH_DonGia] [float] NULL,
	[HH_HinhAnh] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[HH_Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



GO
CREATE TABLE [dbo].[CHI_TIET_HD_XUAT](
	[HDX_Ma] [varchar](5) NOT NULL,
	[HH_Ma] [varchar](5) NOT NULL,
	[SoLuongXuat] [int] NULL,
	[DonGiaNhap] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[HDX_Ma] ASC,
	[HH_Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]




GO
CREATE TABLE [dbo].[CHITIET_HD_NHAP](
	[HDN_Ma] [varchar](5) NOT NULL,
	[HH_Ma] [varchar](5) NOT NULL,
	[SoLuongNhap] [int] NULL,
	[DonGiaNhap] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[HDN_Ma] ASC,
	[HH_Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TAI_KHOAN_HE_THONG]  WITH CHECK ADD FOREIGN KEY([PQ_Ma])
REFERENCES [dbo].[PHAN_QUYEN] ([PQ_Ma])
GO

ALTER TABLE [dbo].[HOA_DON_XUAT]  WITH CHECK ADD FOREIGN KEY([MA_KH])
REFERENCES [dbo].[KHACH_HANG] ([MA_KH])
GO

ALTER TABLE [dbo].[HOA_DON_XUAT]  WITH CHECK ADD FOREIGN KEY([TKHT_Email])
REFERENCES [dbo].[TAI_KHOAN_HE_THONG] ([TKHT_Email])
GO

ALTER TABLE [dbo].[HOA_DON_NHAP]  WITH CHECK ADD FOREIGN KEY([NCC_Ma])
REFERENCES [dbo].[NHA_CUNG_CAP] ([NCC_Ma])
GO

ALTER TABLE [dbo].[HOA_DON_NHAP]  WITH CHECK ADD FOREIGN KEY([TKHT_Email])
REFERENCES [dbo].[TAI_KHOAN_HE_THONG] ([TKHT_Email])
GO

ALTER TABLE [dbo].[HANGHOA]  WITH CHECK ADD FOREIGN KEY([LH_Ma])
REFERENCES [dbo].[LOAI_HANG] ([LH_Ma])
GO


ALTER TABLE [dbo].[HANGHOA]  WITH CHECK ADD FOREIGN KEY([NSX_ma])
REFERENCES [dbo].[NUOC_SAN_XUAT] ([NSX_Ma])
GO

ALTER TABLE [dbo].[HANGHOA]  WITH CHECK ADD FOREIGN KEY([NCC_ma])
REFERENCES [dbo].[NHA_CUNG_CAP] ([NCC_ma])
GO

GO
ALTER TABLE [dbo].[CHI_TIET_HD_XUAT]  WITH CHECK ADD FOREIGN KEY([HDX_Ma])
REFERENCES [dbo].[HOA_DON_XUAT] ([HDX_Ma])
GO

ALTER TABLE [dbo].[CHI_TIET_HD_XUAT]  WITH CHECK ADD FOREIGN KEY([HH_Ma])
REFERENCES [dbo].[HANGHOA] ([HH_Ma])
GO


ALTER TABLE [dbo].[CHITIET_HD_NHAP]  WITH CHECK ADD FOREIGN KEY([HDN_Ma])
REFERENCES [dbo].[HOA_DON_NHAP] ([HDN_Ma])
GO
ALTER TABLE [dbo].[CHITIET_HD_NHAP]  WITH CHECK ADD FOREIGN KEY([HH_Ma])
REFERENCES [dbo].[HANGHOA] ([HH_Ma])
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
INSERT INTO LOAI_HANG (LH_Ma, LH_Ten, LH_MoTa, LH_TrangThai)
VALUES ('LH01', N'Cát xây dựng', N'Loại cát dùng để xây dựng', 1),
('LH02', N'Đá 1x2', N'Loại đá có kích thước 1x2', 1),
('LH03', N'Than củi', N'Loại than dùng để đốt lò hơi', 1);
GO
INSERT INTO NUOC_SAN_XUAT (NSX_Ma, NSX_Ten)
VALUES ('NSX01', N'Việt Nam'),
('NSX02', N'Đức'),
('NSX03', N'Mỹ');
GO
INSERT INTO KHACH_HANG (MA_KH, TEN_KH, DIACHI, SDT)
VALUES ('KH01', N'Nguyễn Văn A', N'123 Đường ABC, Quận 1, TP. HCM', '0123456789'),
('KH02', N'Trần Thị B', N'456 Đường XYZ, Quận 2, TP. HCM', '0123456789'),
('KH03', N'Lê Văn C', N'789 Đường LMN, Quận 3, TP. HCM', '0123456789');
GO


Go
INSERT INTO TAI_KHOAN_HE_THONG (TKHT_Email, PQ_Ma, TKHT_Password, TKHT_DiaChi, TKHT_SoDienThoai, TKHT_GioiTinh, TKHT_NgaySinh)
VALUES ('admin@localhost.com', 'PQ01', '123456', 'Ha Noi', '0987654321', 1, '2000-01-01')
GO
INSERT INTO TAI_KHOAN_HE_THONG (TKHT_Email, PQ_Ma, TKHT_Password, TKHT_DiaChi, TKHT_SoDienThoai, TKHT_GioiTinh, TKHT_NgaySinh)
VALUES ('CEO@localhost.com', 'PQ02', '123456', 'Ha Noi', '0987654321', 1, '1990-01-01')
GO
INSERT INTO TAI_KHOAN_HE_THONG (TKHT_Email, PQ_Ma, TKHT_Password, TKHT_DiaChi, TKHT_SoDienThoai, TKHT_GioiTinh, TKHT_NgaySinh)
VALUES ('emp1@localhost.com', 'PQ03', '123456', 'Ha Noi', '0987654321', 0, '1995-01-01')
GO
GO
INSERT INTO TAI_KHOAN_HE_THONG (TKHT_Email, PQ_Ma, TKHT_Password, TKHT_DiaChi, TKHT_SoDienThoai, TKHT_GioiTinh, TKHT_NgaySinh)
VALUES ('emp2@localhost.com', 'PQ03', '123456', 'Ha Tinh', '087654321', 0, '2002-01-01')
GO


--Tao Prco 
CREATE PROC proc_login
	@email varchar(30),
	@pass varchar(20),
	@roles int
as
BEGIN
	Select * from TAI_KHOAN_HE_THONG where TKHT_Email = @email AND TKHT_Password = @pass
END;
GO

CREATE PROC [dbo].[ListOfProducts]
AS BEGIN
SELECT * FROM dbo.HANGHOA
END
GO

CREATE PROCEDURE proc_check_login
	@email varchar(30),
	@pass varchar(20)
as
BEGIN
Select * from TAI_KHOAN_HE_THONG where TKHT_Email = @email AND TKHT_Password = @pass
END;
GO


GO
CREATE PROCEDURE InsertProduct
    @mahang VARCHAR(5),
    @maloai VARCHAR(5),
    @manuocsx VARCHAR(6),
    @manhacungcap varchar(5),
    @tenhang nvarchar(50),
    @soluonghang int,
    @motahang nvarchar(100),
    @dongiahang float,
    @hinhanh varchar(max)

AS
BEGIN
    INSERT INTO HANGHOA
    VALUES (@mahang, @maloai, @manuocsx, @manhacungcap, @tenhang, @motahang, @dongiahang, @hinhanh, @soluonghang)
END
GO
Go
CREATE PROCEDURE UpdateProduct
    @mahang VARCHAR(5),
    @maloai VARCHAR(5),
    @manuocsx VARCHAR(6),
    @manhacungcap varchar(5),
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

GO
CREATE PROC DeleteofProduct
@mahang varchar(5)
AS BEGIN
DECLARE @kq BIT = 1
IF EXISTS(SELECT * FROM HANGHOA WHERE HH_Ma = @mahang)
	DELETE dbo.HANGHOA WHERE HH_Ma = @mahang
ELSE
	SET @kq = 0
SELECT @kq
END
GO
GO
GO
CREATE PROC [dbo].[SearchProduct]
@tenhanghoa NVARCHAR(50)
AS BEGIN
SELECT * FROM dbo.HANGHOA WHERE HH_Ten LIKE '%' + @tenhanghoa + '%'
END
GO

CREATE PROCEDURE InsertCustomers
    @makh VARCHAR(5),
    @tenkh nvarchar(20),
    @diachi nvarchar(100),
    @sdt varchar(10)

AS
BEGIN
    INSERT INTO KHACH_HANG
    VALUES (@makh, @tenkh, @diachi, @sdt)
END
GO

CREATE PROCEDURE UpdateCustomers
    @makh VARCHAR(5),
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

CREATE PROC [dbo].[SearchCustomers]
@ten NVARCHAR(50)
AS BEGIN
SELECT * FROM dbo.KHACH_HANG WHERE TEN_KH LIKE '%' + @ten + '%'
END
GO



INSERT INTO [dbo].[HANGHOA] ([HH_Ma], [LH_Ma], [NSX_ma], [HH_Ten], [HH_MoTa], [HH_DonGia], [HH_HinhAnh])
VALUES
('HH02', 'LH01', 'NSX01', N'Cát xây dựng Việt Nam', N'Cát xây dựng Việt Nam tiêu chuẩn', 13000, NULL),
('HH03', 'LH02', 'NSX01', N'Đá 1x2 Việt Nam', N'Đá 1x2 Việt Nam chất lượng cao', 25000, NULL),
('HH04', 'LH02', 'NSX01', N'Đá 1x2 Việt Nam', N'Đá 1x2 Việt Nam tiêu chuẩn', 22000, NULL),
('HH05', 'LH03', 'NSX02', N'Than củi Đức', N'Than củi Đức chất lượng cao', 80000, NULL),
('HH06', 'LH03', 'NSX02', N'Than củi Đức', N'Than củi Đức tiêu chuẩn', 75000, NULL),
('HH07', 'LH01', 'NSX03', N'Cát xây dựng Mỹ', N'Cát xây dựng Mỹ chất lượng cao', 18000, NULL),
('HH08', 'LH01', 'NSX03', N'Cát xây dựng Mỹ', N'Cát xây dựng Mỹ tiêu chuẩn', 16000, NULL),
('HH09', 'LH02', 'NSX03', N'Đá 1x2 Mỹ', N'Đá 1x2 Mỹ chất lượng cao', 28000, NULL),
('HH10', 'LH02', 'NSX03', N'Đá 1x2 Mỹ', N'Đá 1x2 Mỹ tiêu chuẩn', 25000, NULL)
Go