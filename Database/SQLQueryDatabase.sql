CREATE DATABASE QL_PM3
GO

USE QL_PM3
GO
-- Quan ly nhan vien
CREATE TABLE CHUCVU
(
	MaChucVu VARCHAR(15) PRIMARY KEY,
	TenChucVu NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE LOAINHANVIEN
(
	MaLoaiNhanVien VARCHAR(15) PRIMARY KEY,
	TenLoaiNhanVien NVARCHAR(100) NOT NULL
)
GO
------------
CREATE TABLE TINHTRANGLAMVIEC
(
	MaTTLV VARCHAR(15) PRIMARY KEY,
	TenTTLV NVARCHAR(100) NOT NULL
)
GO
--Phòng khám
CREATE TABLE PHONGKHAM
(
	MaPhongKham VARCHAR(15) PRIMARY KEY,
	TenPhongKham NVARCHAR(100)NOT NULL,
	HangDoi INT NOT NULL,
	HieuHangDoi INT NOT NULL
    
)
GO
-- Quan ly tai khoan
CREATE TABLE LOAITAIKHOAN
(
	MaLoaiTaiKhoan VARCHAR(15) PRIMARY KEY,
	TenLoaiTaiKhoan NVARCHAR(100) NOT NULL
)
GO
-- Bảng đơn vị
CREATE TABLE DONVI
(
	ma INT IDENTITY(1,1) PRIMARY KEY,
	DonVi NVARCHAR(50) NOT NULL
)

-- Dược phẩm
CREATE TABLE LOAIDUOCPHAM
(
	MaLoaiDuocPham VARCHAR(15) PRIMARY KEY,
	TenLoaiDuocPham NVARCHAR(100)NOT NULL,
)
GO
CREATE TABLE DICHVUKYTHUATYTE
(
	MaDVKyThuat VARCHAR(15) PRIMARY KEY,
	TenDVKyThuat NVARCHAR(200) NOT NULL,
	ChiPhiSuDungDV VARCHAR(15) NOT NULL,
)
GO
-- Dịch vụ sơ cứu tại chỗ
CREATE TABLE DICHVUSOCUUTAICHO
(
	MaLoaiDVSoCuu VARCHAR(15) PRIMARY KEY,
	TenLoaiDV NVARCHAR(100) NOT NULL,
)
GO
-- Quan ly Nha Cung Cap
 CREATE TABLE NHACUNGCAP
(
	MaNhaCungCap VARCHAR(15) PRIMARY KEY,
	TenNhaCungCap NVARCHAR(100) NOT NULL,
	DiaChi NVARCHAR(100) NOT NULL,
	SoDienThoai VARCHAR(20) NOT NULL,
	Email VARCHAR(50)NOT NULL,
	MatHangCungCap NVARCHAR(100) NOT NULL,
	SoTaiKhoan VARCHAR(20),
	NganHang NVARCHAR(100),
	TinhTrangCungCap NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE NHANVIEN
(
	MaNhanVien VARCHAR(15) PRIMARY KEY,
	MaLoaiNhanVien VARCHAR(15) NOT NULL,
	MaChucVu VARCHAR(15) NOT NULL,
	MaTTLV VARCHAR(15) NOT NULL,
	MaPhongKham VARCHAR(15),

	TenNhanVien NVARCHAR(100) NOT NULL,
	NgaySinh DATE NOT NULL,
	GioiTinh NVARCHAR(10) NOT NULL,
	SoDienThoai VARCHAR(20) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	NgayVaoLam DATE NOT NULL,
	TienLuong VARCHAR(15) NOT NULL,
	TienTroCap VARCHAR(15),
	TienThuong VARCHAR(15),

	FOREIGN KEY (MaPhongKham) REFERENCES dbo.PHONGKHAM(MaPhongKham),
	FOREIGN KEY (MaLoaiNhanVien) REFERENCES dbo.LOAINHANVIEN(MaLoaiNhanVien),
	FOREIGN KEY (MaChucVu) REFERENCES dbo.CHUCVU(MaChucVu),
	FOREIGN KEY (MaTTLV) REFERENCES dbo.TINHTRANGLAMVIEC(MaTTLV),

)
GO
------------------------------------------------------------------------------------
-- Chấm công
CREATE TABLE CHAMCONG
(
	MaChamCong VARCHAR(15) PRIMARY KEY,
	MaNhanVien VARCHAR(15) NOT NULL,
	NgayChamCong DATE NOT NULL DEFAULT GETDATE(),
	NghiCoPhep NVARCHAR(10) NOT NULL,

	FOREIGN KEY (MaNhanVien) REFERENCES dbo.NHANVIEN(MaNhanVien),
)
GO
-- tài khoản
CREATE TABLE TAIKHOAN
(
	Username VARCHAR(100) PRIMARY KEY,
	MaLoaiTaiKhoan VARCHAR(15) NOT NULL,
	MaNhanVien VARCHAR(15),
	
	Password1 VARCHAR(50) NOT NULL,
	Password2 VARCHAR(50)

	FOREIGN KEY (MaLoaiTaiKhoan) REFERENCES dbo.LOAITAIKHOAN(MaLoaiTaiKhoan),
	FOREIGN KEY (MaNhanVien) REFERENCES dbo.NHANVIEN(MaNhanVien),
)
GO

--Phiếu nhập hàng
CREATE TABLE PHIEUNHAPHANG
(
	MaPhieuNhapHang VARCHAR(15) PRIMARY KEY,
	MaNhaCungCap VARCHAR(15) NOT NULL,
	NgayNhap DATE,
	SoLuongDanhMucHangNhap VARCHAR(10) NOT NULL,
	SoTien VARCHAR(15) NOT NULL,
	TinhTrang NVARCHAR(50) NOT NULL

	FOREIGN KEY (MaNhaCungCap) REFERENCES dbo.NHACUNGCAP(MaNhaCungCap),
)
GO




-- Dụng cụ y tế
CREATE TABLE DUNGCUYTE
(
	MaDungCuYTe VARCHAR(15) PRIMARY KEY,
	MaLoaiDuocPham VARCHAR(15) NOT NULL,
	TenDungCuYTe NVARCHAR(100)NOT NULL,
	CongDung NVARCHAR(200)NOT NULL,
	DonVi NVARCHAR(50)NOT NULL,
	GiaNhap VARCHAR(15) NOT NULL,
	NgayNhap DATE NOT NULL DEFAULT GETDATE(),
	TinhTrangSuDung NVARCHAR(50) NOT NULL,

	FOREIGN KEY (MaLoaiDuocPham) REFERENCES dbo.LOAIDUOCPHAM(MaLoaiDuocPham),
)
GO
-- Thuốc Khám
CREATE TABLE THUOCKHAM
(
	MaThuocKham VARCHAR(15) PRIMARY KEY,
	MaLoaiDuocPham VARCHAR(15) NOT NULL,
	TenThuocKham NVARCHAR(100)NOT NULL,
	CongDung NVARCHAR(100)NOT NULL,
	DonVi NVARCHAR(50)NOT NULL,
	GiaThuocNhap VARCHAR(15) NOT NULL,
	NgayNhap DATE NOT NULL DEFAULT GETDATE(),
	TinhTrangConSD NVARCHAR(50) NOT NULL,
	GiaThuocBan VARCHAR(15) NOT NULL,
	SoLuongCon INT NOT NULL,

	FOREIGN KEY (MaLoaiDuocPham) REFERENCES dbo.LOAIDUOCPHAM(MaLoaiDuocPham),
)
GO

--Chi tiết phiếu nhập
CREATE TABLE CHITIETPHIEUNHAP
(
	MaPhieuNhapHang VARCHAR(15) NOT NULL,
	MaLoaiDuocPham VARCHAR(15) NOT NULL,
	DonVi NVARCHAR(50) NOT NULL,
	MaHangNhap VARCHAR(15) NOT NULL,
	TenHangNhap NVARCHAR(100) NOT NULL,
	CongDung NVARCHAR(50) NOT NULL,
	GiaNhap VARCHAR(15) NOT NULL,
	NgayNhap DATE NOT NULL DEFAULT GETDATE(),
	SoLuongNhap INT NOT NULL,

	FOREIGN KEY (MaPhieuNhapHang) REFERENCES dbo.PHIEUNHAPHANG(MaPhieuNhapHang),
	FOREIGN KEY (MaLoaiDuocPham) REFERENCES dbo.LOAIDUOCPHAM(MaLoaiDuocPham),
	
)
GO
-- Bệnh nhân
CREATE TABLE BENHNHAN
(
	MaBenhNhan VARCHAR(15) PRIMARY KEY,
	HoTenBenhNhan NVARCHAR(100) NOT NULL,
	Tuoi INT NOT NULL,
	GioiTinh NVARCHAR(10) NOT NULL,
	SoCMND VARCHAR(15) NOT NULL,
	DiaChi NVARCHAR(200) NOT NULL,
	NgayKhamBenh DATE NOT NULL DEFAULT GETDATE(),
	ChuanDonSoLuot NVARCHAR(200) NOT NULL,
	MaPhongKham1 VARCHAR(15) NOT NULL,
	STTPhongKham1 INT NOT NULL,
	MaPhongKham2 VARCHAR(15),
	STTPhongKham2 INT ,
	MaPhongKham3 VARCHAR(15),
	STTPhongKham3 INT,
	ThuVienPhi NVARCHAR(15) NOT NULL,
	NhanThuoc NVARCHAR(15) NOT NULL,

	FOREIGN KEY (MaPhongKham1) REFERENCES dbo.PHONGKHAM(MaPhongKham),
	FOREIGN KEY (MaPhongKham2) REFERENCES dbo.PHONGKHAM(MaPhongKham),
	FOREIGN KEY (MaPhongKham3) REFERENCES dbo.PHONGKHAM(MaPhongKham),
)
GO
-- Bảng lưu bệnh nhân và phòng khám (1:1)
CREATE TABLE BENHNHAN_TAM
(
	STTPhongKham INT NOT NULL,
	MaPhongKham VARCHAR(15) NOT NULL,
	MaBenhNhan VARCHAR(15) NOT NULL,
	HoTenBenhNhan NVARCHAR(100) NOT NULL,
	Tuoi INT NOT NULL,
	GioiTinh NVARCHAR(10) NOT NULL,
	SoCMND VARCHAR(15) NOT NULL,
	ChuanDonSoLuot NVARCHAR(200) NOT NULL,
)
GO
-- Phiếu Khám
CREATE TABLE PHIEUKHAM
(
	
	MaPhieuKham VARCHAR(15) PRIMARY KEY,
	MaNhanVien VARCHAR(15) NOT NULL,
	MaBenhNhan VARCHAR(15) NOT NULL,
	NgayKham DATE NOT NULL DEFAULT GETDATE(),
	ChuanDoanBenh NVARCHAR(200) NOT NULL,
	KeDonThuoc NVARCHAR(10) NOT NULL,
	TongTienThuoc VARCHAR(15) NOT NULL ,
	SuDungDVKyThuatYTe NVARCHAR(10) NOT NULL,
	TongTienDVKyThuat VARCHAR(15)NOT NULL,
	SuDungDVSoCuu NVARCHAR(10) NOT NULL,
	TongTienDVSoCuu VARCHAR(15)NOT NULL,

	FOREIGN KEY (MaNhanVien) REFERENCES dbo.NHANVIEN(MaNhanVien),
	FOREIGN KEY (MaBenhNhan) REFERENCES dbo.BENHNHAN(MaBenhNhan),
)
GO
--Chi tiết toa thuốc khám
CREATE TABLE CHITIETTOATHUOCKHAM
(
	MaPhieuKham VARCHAR(15) NOT NULL,
	MaThuocKham VARCHAR(15) NOT NULL,
	SoLuong INT NOT NULL,
	CachDung NVARCHAR(200) NOT NULL,
	ThanhTien INT NOT NULL,

	FOREIGN KEY (MaPhieuKham) REFERENCES dbo.PHIEUKHAM(MaPhieuKham),
	FOREIGN KEY (MaThuocKham) REFERENCES dbo.THUOCKHAM(MaThuocKham),
)
GO
--Dịch vụ kỹ thuật

-- CHi tiết dịch vụ kỹ thuật y tế
CREATE TABLE CHITIETDVKYTHUATYTE
(
	MaPhieuKham VARCHAR(15) NOT NULL,
	MaDVKyThuat VARCHAR(15) NOT NULL,
	SoLanSD INT NOT NULL,
	ThanhTien INT NOT NULL,

	FOREIGN KEY (MaPhieuKham) REFERENCES dbo.PHIEUKHAM(MaPhieuKham),
	FOREIGN KEY (MaDVKyThuat) REFERENCES dbo.DICHVUKYTHUATYTE(MaDVKyThuat),
)
GO

-- Dược phẩm dịch vụ sơ cứu
CREATE TABLE DUOCPHAMDVYTESOCUU
(
	MaDuocPhamDVSoCuu VARCHAR(15) PRIMARY KEY,
	MaLoaiDuocPham VARCHAR(15) NOT NULL,
	TenDuocPham NVARCHAR(100) NOT NULL,
	CongDung NVARCHAR(200) NOT NULL,
	DonVi NVARCHAR(50) NOT NULL,
	GiaNhap VARCHAR(15) NOT NULL,
	NgayNhap DATE NOT NULL DEFAULT GETDATE(),
	TinhTrangConSD NVARCHAR(50) NOT NULL,
	GiaBan VARCHAR(15) NOT NULL,
	SoLuongCon INT NOT NULL,

	FOREIGN KEY (MaLoaiDuocPham) REFERENCES dbo.LOAIDUOCPHAM(MaLoaiDuocPham),
)
GO
--Chi tiết dịch vụ sơ cứu tại chỗ
CREATE TABLE CHITIETDVSOCUUTAICHO
(
	MaPhieuKham VARCHAR(15) NOT NULL,
	MaDuocPhamDVSoCuu VARCHAR(15) NOT NULL,
	MaLoaiDVSoCuu VARCHAR(15) NOT NULL,
	SoLuong INT NOT NULL,
	ThanhTien INT NOT NULL,

	FOREIGN KEY (MaPhieuKham) REFERENCES dbo.PHIEUKHAM(MaPhieuKham),
	FOREIGN KEY (MaDuocPhamDVSoCuu) REFERENCES dbo.DUOCPHAMDVYTESOCUU(MaDuocPhamDVSoCuu),
	FOREIGN KEY (MaLoaiDVSoCuu) REFERENCES dbo.DICHVUSOCUUTAICHO(MaLoaiDVSoCuu),
)
GO
--Hóa Đơn thu Tiền
CREATE TABLE HOADONTHUTIEN
(
	MaHoaDonThuTien VARCHAR(15) PRIMARY KEY,
	MaBenhNhan VARCHAR(15) NOT NULL,
	MaPhieuKham1 VARCHAR(15) NOT NULL,
	MaPhieuKham2 VARCHAR(15) ,
	MaPhieuKham3 VARCHAR(15),
	NgayLapHoaDon DATE NOT NULL DEFAULT GETDATE(),
	TienKham VARCHAR(15) NOT NULL,
	TienThuoc VARCHAR(15) NOT NULL,
	TienSuDungDVKyThuatYTe VARCHAR(15),
	TienSuDungDVSoCuu VARCHAR(15),
	TongTien VARCHAR(15) NOT NULL,

	FOREIGN KEY (MaBenhNhan) REFERENCES dbo.BENHNHAN(MaBenhNhan),
	FOREIGN KEY (MaPhieuKham1) REFERENCES dbo.PHIEUKHAM(MaPhieuKham),
	FOREIGN KEY (MaPhieuKham2) REFERENCES dbo.PHIEUKHAM(MaPhieuKham),
	FOREIGN KEY (MaPhieuKham3) REFERENCES dbo.PHIEUKHAM(MaPhieuKham),
)
GO
--Chi tiết phiếu nhập
CREATE TABLE CHITIETPHIEUNHAP_TAM
(
	MaPhieuNhapHang VARCHAR(15) NOT NULL,
	MaLoaiDuocPham VARCHAR(15) NOT NULL,
	DonVi NVARCHAR(50) NOT NULL,
	MaHangNhap VARCHAR(15) NOT NULL,
	TenHangNhap NVARCHAR(100) NOT NULL,
	CongDung NVARCHAR(200) NOT NULL,
	GiaNhap VARCHAR(15) NOT NULL,
	NgayNhap DATE NOT NULL DEFAULT GETDATE(),
	SoLuongNhap INT NOT NULL
)
GO


--------------------------------------------------------------
--------------------------------------------------------------
--------------------------------------------------------------
-- [chèn dữ liệu mặt định]
--------------------------------------------------------------
--------------------------------------------------------------
--> LOẠI DƯỢC PHẨM
--------------------------------------------------------------
--------------------------------------------------------------
INSERT INTO dbo.LOAIDUOCPHAM
VALUES
(   'DP001', -- MaLoaiDuocPham - varchar(10)
    N'Thuốc khám' -- TenLoaiDuocPham - nvarchar(100)
    )

INSERT INTO dbo.LOAIDUOCPHAM
VALUES
(   'DP002', -- MaLoaiDuocPham - varchar(10)
    N'Dụng cụ y tế' -- TenLoaiDuocPham - nvarchar(100)
    )

INSERT INTO dbo.LOAIDUOCPHAM
VALUES
(   'DP003', -- MaLoaiDuocPham - varchar(10)
    N'Dược phẩm dịch vụ sơ cứu' -- TenLoaiDuocPham - nvarchar(100)
    )
GO
------------------------------------------------------------------
------------------------------------------------------------------
--> PHÒNG KHÁM
------------------------------------------------------------------
------------------------------------------------------------------
INSERT INTO dbo.PHONGKHAM
VALUES
(   'PGKH01',  -- MaPhongKham - varchar(15)
    N'Tai - Mũi - Họng', -- TenPhongKham - nvarchar(100)
    0,   -- HangDoi - int
    0    -- HieuHangDoi - int
    )

INSERT INTO dbo.PHONGKHAM
VALUES
(   'PGKH02',  -- MaPhongKham - varchar(15)
    N'Răng - Hàm - Mặt', -- TenPhongKham - nvarchar(100)
    0,   -- HangDoi - int
    0    -- HieuHangDoi - int
    )

INSERT INTO dbo.PHONGKHAM
VALUES
(   'PGKH03',  -- MaPhongKham - varchar(15)
    N'Tim mạch', -- TenPhongKham - nvarchar(100)
    0,   -- HangDoi - int
    0    -- HieuHangDoi - int
    )

INSERT INTO dbo.PHONGKHAM
VALUES
(   'PGKH04',  -- MaPhongKham - varchar(15)
    N'Chỉnh hình', -- TenPhongKham - nvarchar(100)
    0,   -- HangDoi - int
    0    -- HieuHangDoi - int
    )

INSERT INTO dbo.PHONGKHAM
VALUES
(   'PGKH05',  -- MaPhongKham - varchar(15)
    N'Da liễu', -- TenPhongKham - nvarchar(100)
    0,   -- HangDoi - int
    0    -- HieuHangDoi - int
    )

INSERT INTO dbo.PHONGKHAM
VALUES
(   'PGKH06',  -- MaPhongKham - varchar(15)
    N'Tiêu hóa', -- TenPhongKham - nvarchar(100)
    0,   -- HangDoi - int
    0    -- HieuHangDoi - int
    )
INSERT INTO dbo.PHONGKHAM
VALUES
(   'PGKH07',  -- MaPhongKham - varchar(15)
    N'Đa khoa', -- TenPhongKham - nvarchar(100)
    0,   -- HangDoi - int
    0    -- HieuHangDoi - int
    )
GO
	---------------------------------------------------------
	---------------------------------------------------------
--> Chức vụ
	--------------------------------------------------------
	--------------------------------------------------------
INSERT INTO dbo.CHUCVU
VALUES
(   'CV01', -- MaChucVu - varchar(15)
    N'Quản lý' -- TenChucVu - nvarchar(100)
    )

INSERT INTO dbo.CHUCVU
VALUES
(   'CV02', -- MaChucVu - varchar(15)
    N'Bác sĩ' -- TenChucVu - nvarchar(100)
    )

INSERT INTO dbo.CHUCVU
VALUES
(   'CV03', -- MaChucVu - varchar(15)
    N'Nhân viên' -- TenChucVu - nvarchar(100)
    )
INSERT INTO dbo.CHUCVU
VALUES
(   'CV04', -- MaChucVu - varchar(15)
    N'Dược sĩ' -- TenChucVu - nvarchar(100)
    )
GO
---------------------------------------------------------
----------------------------------------------------------
--> Tình trạng làm việc
---------------------------------------------------------
---------------------------------------------------------
INSERT INTO dbo.TINHTRANGLAMVIEC
(
    MaTTLV,
    TenTTLV
)
VALUES
(   'TTLV01', -- MaTTLV - varchar(15)
    N'Đang làm việc' -- TenTTLV - nvarchar(100)
    )
INSERT INTO dbo.TINHTRANGLAMVIEC
(
    MaTTLV,
    TenTTLV
)
VALUES
(   'TTLV02', -- MaTTLV - varchar(15)
    N'Ngừng làm việc' -- TenTTLV - nvarchar(100)
    )
INSERT INTO dbo.TINHTRANGLAMVIEC
(
    MaTTLV,
    TenTTLV
)
VALUES
(   'TTLV03', -- MaTTLV - varchar(15)
    N'Nghỉ phép dài hạng' -- TenTTLV - nvarchar(100)
    )
GO
----------------------------------------------------
----------------------------------------------------
--> Loại nhân viên
-----------------------------------------------------
----------------------------------------------------
INSERT INTO dbo.LOAINHANVIEN
VALUES
(   'LNV01', -- MaLoaiNhanVien - varchar(15)
    N'Bác sĩ' -- TenLoaiNhanVien - nvarchar(100)
    )

INSERT INTO dbo.LOAINHANVIEN
VALUES
(   'LNV02', -- MaLoaiNhanVien - varchar(15)
    N'Điều dưỡng' -- TenLoaiNhanVien - nvarchar(100)
    )

INSERT INTO dbo.LOAINHANVIEN
VALUES
(   'LNV03', -- MaLoaiNhanVien - varchar(15)
    N'Dược sĩ' -- TenLoaiNhanVien - nvarchar(100)
    )

INSERT INTO dbo.LOAINHANVIEN
VALUES
(   'LNV04', -- MaLoaiNhanVien - varchar(15)
    N'Lễ tân' -- TenLoaiNhanVien - nvarchar(100)
    )

INSERT INTO dbo.LOAINHANVIEN
VALUES
(   'LNV05', -- MaLoaiNhanVien - varchar(15)
    N'Thu ngân' -- TenLoaiNhanVien - nvarchar(100)
    )

INSERT INTO dbo.LOAINHANVIEN
VALUES
(   'LNV06', -- MaLoaiNhanVien - varchar(15)
    N'Thủ kho' -- TenLoaiNhanVien - nvarchar(100)
    )

INSERT INTO dbo.LOAINHANVIEN
VALUES
(   'LNV07', -- MaLoaiNhanVien - varchar(15)
    N'Kỹ thuật viên' -- TenLoaiNhanVien - nvarchar(100)
    )

INSERT INTO dbo.LOAINHANVIEN
VALUES
(   'LNV08', -- MaLoaiNhanVien - varchar(15)
    N'Tạp vụ' -- TenLoaiNhanVien - nvarchar(100)
    )
GO
-------------------------------------------------------------
-------------------------------------------------------------
--Loại tài khoản
-------------------------------------------------------------
-------------------------------------------------------------
INSERT INTO dbo.LOAITAIKHOAN
VALUES
(   'LTK00', -- MaLoaiTaiKhoan - varchar(15)
    N'Admin' -- TenLoaiTaiKhoan - nvarchar(100)
    )
INSERT INTO dbo.LOAITAIKHOAN
VALUES
(   'LTK01', -- MaLoaiTaiKhoan - varchar(15)
    N'Bác sĩ răng hàm mặt' -- TenLoaiTaiKhoan - nvarchar(100)
    )

INSERT INTO dbo.LOAITAIKHOAN
VALUES
(   'LTK02', -- MaLoaiTaiKhoan - varchar(15)
    N'Bác sĩ tai mũi họng' -- TenLoaiTaiKhoan - nvarchar(100)
    )

INSERT INTO dbo.LOAITAIKHOAN
VALUES
(   'LTK03', -- MaLoaiTaiKhoan - varchar(15)
    N'Bác sĩ tim mạch' -- TenLoaiTaiKhoan - nvarchar(100)
    )

INSERT INTO dbo.LOAITAIKHOAN
VALUES
(   'LTK04', -- MaLoaiTaiKhoan - varchar(15)
    N'Bác sĩ da liễu' -- TenLoaiTaiKhoan - nvarchar(100)
    )

INSERT INTO dbo.LOAITAIKHOAN
VALUES
(   'LTK05', -- MaLoaiTaiKhoan - varchar(15)
    N'Bác sĩ nội tiêu hóa' -- TenLoaiTaiKhoan - nvarchar(100)
    )

INSERT INTO dbo.LOAITAIKHOAN
VALUES
(   'LTK06', -- MaLoaiTaiKhoan - varchar(15)
    N'Bác sĩ chỉnh hình' -- TenLoaiTaiKhoan - nvarchar(100)
    )

INSERT INTO dbo.LOAITAIKHOAN
VALUES
(   'LTK07', -- MaLoaiTaiKhoan - varchar(15)
    N'Nhân viên thủ kho' -- TenLoaiTaiKhoan - nvarchar(100)
    )

INSERT INTO dbo.LOAITAIKHOAN
VALUES
(   'LTK08', -- MaLoaiTaiKhoan - varchar(15)
    N'Lễ tân' -- TenLoaiTaiKhoan - nvarchar(100)
    )

INSERT INTO dbo.LOAITAIKHOAN
VALUES
(   'LTK09', -- MaLoaiTaiKhoan - varchar(15)
    N'Thu ngân' -- TenLoaiTaiKhoan - nvarchar(100)
    )
INSERT INTO dbo.LOAITAIKHOAN
VALUES
(   'LTK10', -- MaLoaiTaiKhoan - varchar(15)
    N'Bác sĩ đa khoa' -- TenLoaiTaiKhoan - nvarchar(100)
    )
INSERT INTO dbo.LOAITAIKHOAN
VALUES
(   'LTK11', -- MaLoaiTaiKhoan - varchar(15)
    N'Dược sĩ' -- TenLoaiTaiKhoan - nvarchar(100)
    )
GO
-----------------------------------------------------------------------
-----------------------------------------------------------------------
-- Dịch vụ sơ cứu
-----------------------------------------------------------------------
-----------------------------------------------------------------------
INSERT INTO dbo.DICHVUSOCUUTAICHO
VALUES
(   'DVSC01', -- MaLoaiDVSoCuu - varchar(15)
    N'Truyền nước' -- TenLoaiDV - nvarchar(100)
    )

INSERT INTO dbo.DICHVUSOCUUTAICHO
VALUES
(   'DVSC02', -- MaLoaiDVSoCuu - varchar(15)
    N'Chích kim' -- TenLoaiDV - nvarchar(100)
    )

INSERT INTO dbo.DICHVUSOCUUTAICHO
VALUES
(   'DVSC03', -- MaLoaiDVSoCuu - varchar(15)
    N'Băng bó' -- TenLoaiDV - nvarchar(100)
    )
GO
----------------------------------------------------------
----------------------------------------------------------
-- Dịch vụ kỹ thuật y tế
----------------------------------------------------------
----------------------------------------------------------
INSERT INTO dbo.DICHVUKYTHUATYTE
VALUES
(   'DVKT01',  -- MaDVKyThuat - varchar(15)
    N'Siêu âm', -- TenDVKyThuat - nvarchar(200)
    '100000'   -- ChiPhiSuDungDV - varchar(15)
    )
INSERT INTO dbo.DICHVUKYTHUATYTE
VALUES
(   'DVKT02',  -- MaDVKyThuat - varchar(15)
    N'Xét nghiệm', -- TenDVKyThuat - nvarchar(200)
    '300000'   -- ChiPhiSuDungDV - varchar(15)
    )
INSERT INTO dbo.DICHVUKYTHUATYTE
VALUES
(   'DVKT03',  -- MaDVKyThuat - varchar(15)
    N'Chụp X quang', -- TenDVKyThuat - nvarchar(200)
    '200000'   -- ChiPhiSuDungDV - varchar(15)
    )
INSERT INTO dbo.DICHVUKYTHUATYTE
VALUES
(   'DVKT04',  -- MaDVKyThuat - varchar(15)
    N'Nội soi', -- TenDVKyThuat - nvarchar(200)
    '200000'   -- ChiPhiSuDungDV - varchar(15)
    )
GO
--------------------------------------------------------------------
--------------------------------------------------------------------
-- Nhân viên
--------------------------------------------------------------------
--------------------------------------------------------------------
INSERT INTO dbo.NHANVIEN -- Bác sĩ tai mũi họng
VALUES
(   'NV001',        -- MaNhanVien - varchar(15)
    'LNV01',        -- MaLoaiNhanVien - varchar(15) - Bác sĩ
    'CV02',        -- MaChucVu - varchar(15)        - Bác sĩ
    'TTLV01',        -- MaTTLV - varchar(15)        - Đang làm việc
    'PGKH01',        -- MaPhongKham - varchar(15)   - Phòng tai mũi họng
    N'Nguyễn Văn A',       -- TenNhanVien - nvarchar(100)
    '1997/06/20', -- NgaySinh - date
    N'Nam',       -- GioiTinh - nvarchar(10)
    '0367611007',        -- SoDienThoai - varchar(20)
    '@gmail.com',        -- Email - varchar(50)
    GETDATE(), -- NgayVaoLam - date
    '7000000',        -- TienLuong - varchar(15)
    '500000',        -- TienTroCap - varchar(15)
    '500000'         -- TienThuong - varchar(15)
    )
INSERT INTO dbo.NHANVIEN -- Bác sĩ răng hàm mặt
VALUES
(   'NV002',        -- MaNhanVien - varchar(15)
    'LNV01',        -- MaLoaiNhanVien - varchar(15) - Bác sĩ
    'CV02',        -- MaChucVu - varchar(15)        - Bác sĩ
    'TTLV01',        -- MaTTLV - varchar(15)        - Đang làm việc
    'PGKH02',        -- MaPhongKham - varchar(15)   - Phòng răng hàm mặt
    N'Nguyễn Thị D',       -- TenNhanVien - nvarchar(100)
    '1990/06/20', -- NgaySinh - date
    N'Nữ',       -- GioiTinh - nvarchar(10)
    '0367611007',        -- SoDienThoai - varchar(20)
    '@gmail.com',        -- Email - varchar(50)
    GETDATE(), -- NgayVaoLam - date
    '7000000',        -- TienLuong - varchar(15)
    '500000',        -- TienTroCap - varchar(15)
    '500000'         -- TienThuong - varchar(15)
    )
INSERT INTO dbo.NHANVIEN -- Bác sĩ tim mạch
VALUES
(   'NV009',        -- MaNhanVien - varchar(15)
    'LNV01',        -- MaLoaiNhanVien - varchar(15) - Bác sĩ
    'CV02',        -- MaChucVu - varchar(15)        - Bác sĩ
    'TTLV01',        -- MaTTLV - varchar(15)        - Đang làm việc
    'PGKH03',        -- MaPhongKham - varchar(15)   - Phòng Tim mạch
    N'Trần Thị Tuyết N',       -- TenNhanVien - nvarchar(100)
    '1990/06/20', -- NgaySinh - date
    N'Nữ',       -- GioiTinh - nvarchar(10)
    '0367611007',        -- SoDienThoai - varchar(20)
    '@gmail.com',        -- Email - varchar(50)
    GETDATE(), -- NgayVaoLam - date
    '7000000',        -- TienLuong - varchar(15)
    '500000',        -- TienTroCap - varchar(15)
    '500000'         -- TienThuong - varchar(15)
    )
INSERT INTO dbo.NHANVIEN -- Bác sĩ da liễu
VALUES
(   'NV010',        -- MaNhanVien - varchar(15)
    'LNV01',        -- MaLoaiNhanVien - varchar(15) - Bác sĩ
    'CV02',        -- MaChucVu - varchar(15)        - Bác sĩ
    'TTLV01',        -- MaTTLV - varchar(15)        - Đang làm việc
    'PGKH05',        -- MaPhongKham - varchar(15)   - Phòng da liễu
    N'Đặng Thị Phương L',       -- TenNhanVien - nvarchar(100)
    '1995/06/20', -- NgaySinh - date
    N'Nữ',       -- GioiTinh - nvarchar(10)
    '0367611007',        -- SoDienThoai - varchar(20)
    '@gmail.com',        -- Email - varchar(50)
    GETDATE(), -- NgayVaoLam - date
    '7000000',        -- TienLuong - varchar(15)
    '500000',        -- TienTroCap - varchar(15)
    '500000'         -- TienThuong - varchar(15)
    )
INSERT INTO dbo.NHANVIEN -- Bác sĩ tiêu hóa
VALUES
(   'NV011',        -- MaNhanVien - varchar(15)
    'LNV01',        -- MaLoaiNhanVien - varchar(15) - Bác sĩ
    'CV02',        -- MaChucVu - varchar(15)        - Bác sĩ
    'TTLV01',        -- MaTTLV - varchar(15)        - Đang làm việc
    'PGKH06',        -- MaPhongKham - varchar(15)   - Phòng tiêu hóa
    N'Đặng Tuấn V',       -- TenNhanVien - nvarchar(100)
    '1993/08/22', -- NgaySinh - date
    N'Nữ',       -- GioiTinh - nvarchar(10)
    '0367611007',        -- SoDienThoai - varchar(20)
    '@gmail.com',        -- Email - varchar(50)
    GETDATE(), -- NgayVaoLam - date
    '7000000',        -- TienLuong - varchar(15)
    '500000',        -- TienTroCap - varchar(15)
    '500000'         -- TienThuong - varchar(15)
    )
INSERT INTO dbo.NHANVIEN -- Bác sĩ chỉnh hình
VALUES
(   'NV012',        -- MaNhanVien - varchar(15)
    'LNV01',        -- MaLoaiNhanVien - varchar(15) - Bác sĩ
    'CV02',        -- MaChucVu - varchar(15)        - Bác sĩ
    'TTLV01',        -- MaTTLV - varchar(15)        - Đang làm việc
    'PGKH04',        -- MaPhongKham - varchar(15)   - Phòng chỉnh hình
    N'Lê Thanh Tú',       -- TenNhanVien - nvarchar(100)
    '1992/03/10', -- NgaySinh - date
    N'Nữ',       -- GioiTinh - nvarchar(10)
    '0367611007',        -- SoDienThoai - varchar(20)
    '@gmail.com',        -- Email - varchar(50)
    GETDATE(), -- NgayVaoLam - date
    '7000000',        -- TienLuong - varchar(15)
    '500000',        -- TienTroCap - varchar(15)
    '500000'         -- TienThuong - varchar(15)
    )
INSERT INTO dbo.NHANVIEN -- Bác sĩ đa khoa
VALUES
(   'NV007',        -- MaNhanVien - varchar(15)
    'LNV01',        -- MaLoaiNhanVien - varchar(15) - bác sĩ
    'CV02',        -- MaChucVu - varchar(15)        -  bác sĩ
    'TTLV01',        -- MaTTLV - varchar(15)        - Đang làm việc
    'PGKH07',        -- MaPhongKham - varchar(15)   - null
    N'Đặng Kim Lợi',       -- TenNhanVien - nvarchar(100)
    '1984/11/05', -- NgaySinh - date
    N'Nữ',       -- GioiTinh - nvarchar(10)
    '0367611007',        -- SoDienThoai - varchar(20)
    '@gmail.com',        -- Email - varchar(50)
    GETDATE(), -- NgayVaoLam - date
    '60000000',        -- TienLuong - varchar(15)
    '500000',        -- TienTroCap - varchar(15)
    '500000'         -- TienThuong - varchar(15)
    )
INSERT INTO dbo.NHANVIEN -- Dược sĩ
VALUES
(   'NV008',        -- MaNhanVien - varchar(15)
    'LNV03',        -- MaLoaiNhanVien - varchar(15) - bác sĩ
    'CV04',        -- MaChucVu - varchar(15)        -  bác sĩ
    'TTLV01',        -- MaTTLV - varchar(15)        - Đang làm việc
    null,        -- MaPhongKham - varchar(15)   - null
    N'Nguyễn Công Thảo',       -- TenNhanVien - nvarchar(100)
    '1988/12/10', -- NgaySinh - date
    N'Nam',       -- GioiTinh - nvarchar(10)
    '0367611007',        -- SoDienThoai - varchar(20)
    '@gmail.com',        -- Email - varchar(50)
    GETDATE(), -- NgayVaoLam - date
    '60000000',        -- TienLuong - varchar(15)
    '500000',        -- TienTroCap - varchar(15)
    '500000'         -- TienThuong - varchar(15)
    )
INSERT INTO dbo.NHANVIEN -- Nhân viên thủ kho
VALUES
(   'NV003',        -- MaNhanVien - varchar(15)
    'LNV06',        -- MaLoaiNhanVien - varchar(15) - thủ kho
    'CV03',        -- MaChucVu - varchar(15)        - nhân viên
    'TTLV01',        -- MaTTLV - varchar(15)        - Đang làm việc
    null,        -- MaPhongKham - varchar(15)   - null
    N'Nguyễn Thị D',       -- TenNhanVien - nvarchar(100)
    '1992/09/15', -- NgaySinh - date
    N'Nữ',       -- GioiTinh - nvarchar(10)
    '0367611007',        -- SoDienThoai - varchar(20)
    '@gmail.com',        -- Email - varchar(50)
    GETDATE(), -- NgayVaoLam - date
    '7000000',        -- TienLuong - varchar(15)
    '500000',        -- TienTroCap - varchar(15)
    '500000'         -- TienThuong - varchar(15)
    )
INSERT INTO dbo.NHANVIEN -- Nhân viên lễ tân
VALUES
(   'NV004',        -- MaNhanVien - varchar(15)
    'LNV04',        -- MaLoaiNhanVien - varchar(15) - Lễ tuân
    'CV03',        -- MaChucVu - varchar(15)        -  nhân viên
    'TTLV01',        -- MaTTLV - varchar(15)        - Đang làm việc
    null,        -- MaPhongKham - varchar(15)   - null
    N'Huỳnh Thị T',       -- TenNhanVien - nvarchar(100)
    '1996/11/19', -- NgaySinh - date
    N'Nữ',       -- GioiTinh - nvarchar(10)
    '0367611007',        -- SoDienThoai - varchar(20)
    '@gmail.com',        -- Email - varchar(50)
    GETDATE(), -- NgayVaoLam - date
    '6000000',        -- TienLuong - varchar(15)
    '500000',        -- TienTroCap - varchar(15)
    '500000'         -- TienThuong - varchar(15)
    )
INSERT INTO dbo.NHANVIEN -- Nhân viên thu ngân
VALUES
(   'NV005',        -- MaNhanVien - varchar(15)
    'LNV05',        -- MaLoaiNhanVien - varchar(15) - Lễ tuân
    'CV03',        -- MaChucVu - varchar(15)        -  nhân viên
    'TTLV01',        -- MaTTLV - varchar(15)        - Đang làm việc
    null,        -- MaPhongKham - varchar(15)   - null
    N'Đặng Thị M',       -- TenNhanVien - nvarchar(100)
    '1995/01/25', -- NgaySinh - date
    N'Nữ',       -- GioiTinh - nvarchar(10)
    '0367611007',        -- SoDienThoai - varchar(20)
    '@gmail.com',        -- Email - varchar(50)
    GETDATE(), -- NgayVaoLam - date
    '6000000',        -- TienLuong - varchar(15)
    '500000',        -- TienTroCap - varchar(15)
    '500000'         -- TienThuong - varchar(15)
    )
INSERT INTO dbo.NHANVIEN -- Quản lí
VALUES
(   'NV006',        -- MaNhanVien - varchar(15)
    'LNV08',        -- MaLoaiNhanVien - varchar(15) - tạp vụ
    'CV01',        -- MaChucVu - varchar(15)        -  Quản lý
    'TTLV01',        -- MaTTLV - varchar(15)        - Đang làm việc
    null,        -- MaPhongKham - varchar(15)   - null
    N'Lê Hoàng Vy Vy',       -- TenNhanVien - nvarchar(100)
    '1994/08/05', -- NgaySinh - date
    N'Nam',       -- GioiTinh - nvarchar(10)
    '0367611007',        -- SoDienThoai - varchar(20)
    '@gmail.com',        -- Email - varchar(50)
    GETDATE(), -- NgayVaoLam - date
    '60000000',        -- TienLuong - varchar(15)
    '500000',        -- TienTroCap - varchar(15)
    '500000'         -- TienThuong - varchar(15)
    )
GO
---------------------------------------------------------------------
---------------------------------------------------------------------
--Tài khoản
--------------------------------------------------------------------
--------------------------------------------------------------------
INSERT INTO dbo.TAIKHOAN -- admin
VALUES
(   'admin', -- Username - varchar(100)
    'LTK00', -- MaLoaiTaiKhoan - varchar(15)
    null, -- MaNhanVien - varchar(15)
    'admin', -- Password1 - varchar(50)
    'admin'  -- Password2 - varchar(50)
    )
INSERT INTO dbo.TAIKHOAN -- Bác sĩ Răng hạm mặt
VALUES
(   'bacsiranghammat', -- Username - varchar(100)
    'LTK01', -- MaLoaiTaiKhoan - varchar(15)
    'NV002', -- MaNhanVien - varchar(15)
    '123', -- Password1 - varchar(50)
    '123'  -- Password2 - varchar(50)
    )
INSERT INTO dbo.TAIKHOAN -- Bác sĩ tai mũi họng
VALUES
(   'bacsitaimuihong', -- Username - varchar(100)
    'LTK02', -- MaLoaiTaiKhoan - varchar(15)
    'NV001', -- MaNhanVien - varchar(15)
    '123', -- Password1 - varchar(50)
    '123'  -- Password2 - varchar(50)
    )
INSERT INTO dbo.TAIKHOAN -- Bác sĩ tim mạch
VALUES
(   'bacsitimmach', -- Username - varchar(100)
    'LTK03', -- MaLoaiTaiKhoan - varchar(15)
    'NV009', -- MaNhanVien - varchar(15)
    '123', -- Password1 - varchar(50)
    '123'  -- Password2 - varchar(50)
    )
INSERT INTO dbo.TAIKHOAN -- Bác sĩ da liễu
VALUES
(   'bacsidalieu', -- Username - varchar(100)
    'LTK04', -- MaLoaiTaiKhoan - varchar(15)
    'NV010', -- MaNhanVien - varchar(15)
    '123', -- Password1 - varchar(50)
    '123'  -- Password2 - varchar(50)
    )
INSERT INTO dbo.TAIKHOAN -- Bác sĩ noi tiêu hóa
VALUES
(   'bacsinoitieuhoa', -- Username - varchar(100)
    'LTK05', -- MaLoaiTaiKhoan - varchar(15)
    'NV011', -- MaNhanVien - varchar(15)
    '123', -- Password1 - varchar(50)
    '123'  -- Password2 - varchar(50)
    )
INSERT INTO dbo.TAIKHOAN -- Bác sĩ chỉnh hình
VALUES
(   'bacsichinhhinh', -- Username - varchar(100)
    'LTK06', -- MaLoaiTaiKhoan - varchar(15)
    'NV012', -- MaNhanVien - varchar(15)
    '123', -- Password1 - varchar(50)
    '123'  -- Password2 - varchar(50)
    )
INSERT INTO dbo.TAIKHOAN -- Bác sĩ đa khoa
VALUES
(   'bacsidakhoa', -- Username - varchar(100)
    'LTK10', -- MaLoaiTaiKhoan - varchar(15)
    'NV007', -- MaNhanVien - varchar(15)
    '123', -- Password1 - varchar(50)
    '123'  -- Password2 - varchar(50)
    )
INSERT INTO dbo.TAIKHOAN -- Dược sĩ
VALUES
(   'duocsi', -- Username - varchar(100)
    'LTK11', -- MaLoaiTaiKhoan - varchar(15)
    'NV008', -- MaNhanVien - varchar(15)
    '123', -- Password1 - varchar(50)
    '123'  -- Password2 - varchar(50)
    )
INSERT INTO dbo.TAIKHOAN -- nhân viên thủ kho
VALUES
(   'thukho', -- Username - varchar(100)
    'LTK07', -- MaLoaiTaiKhoan - varchar(15)
    'NV003', -- MaNhanVien - varchar(15)
    '123', -- Password1 - varchar(50)
    '123'  -- Password2 - varchar(50)
    )
INSERT INTO dbo.TAIKHOAN -- nhân viên lễ tân
VALUES
(   'letan', -- Username - varchar(100)
    'LTK08', -- MaLoaiTaiKhoan - varchar(15)
    'NV004', -- MaNhanVien - varchar(15)
    '123', -- Password1 - varchar(50)
    '123'  -- Password2 - varchar(50)
    )
INSERT INTO dbo.TAIKHOAN -- nhân viên thu ngân
VALUES
(   'thungan', -- Username - varchar(100)
    'LTK09', -- MaLoaiTaiKhoan - varchar(15)
    'NV005', -- MaNhanVien - varchar(15)
    '123', -- Password1 - varchar(50)
    '123'  -- Password2 - varchar(50)
    )
INSERT INTO dbo.TAIKHOAN -- Quản lí
VALUES
(   'quanli', -- Username - varchar(100)
    'LTK00', -- MaLoaiTaiKhoan - varchar(15)
    'NV006', -- MaNhanVien - varchar(15)
    '123', -- Password1 - varchar(50)
    '123'  -- Password2 - varchar(50)
    )

GO
-------------------------------------------------
-------------------------------------------------
----- Nhà Cung Cấp
-------------------------------------------------
-------------------------------------------------

INSERT INTO dbo.NHACUNGCAP
VALUES
(   'NCC01',  -- MaNhaCungCap - varchar(15)
    N'CÔNG TY TNHH SX & TM DƯỢC PHẨM TÂM BÌNH', -- TenNhaCungCap - nvarchar(100)
    N'349 Kim Mã, Q.Ba Đình, Hà Nội', -- DiaChi - nvarchar(100)
    '18006568',  -- SoDienThoai - varchar(20)
    'duocpham@tambinh.vn',  -- Email - varchar(50)
    N'Dược phẩm', -- MatHangCungCap - nvarchar(100)
    '111222333',  -- SoTaiKhoan - varchar(20)
    N'ACB', -- NganHang - nvarchar(100)
    N'Đang cung cấp'  -- TinhTrangCungCap - nvarchar(50)
    )

INSERT INTO dbo.NHACUNGCAP
VALUES
(   'NCC02',  -- MaNhaCungCap - varchar(15)
    N'CÔNG TY TNHH TM - DV AN HUY', -- TenNhaCungCap - nvarchar(100)
    N'57-59 Ngô Thị Thu Minh, P.2, Q. Tân Bình, Tp.HCM', -- DiaChi - nvarchar(100)
    '02839907405',  -- SoDienThoai - varchar(20)
    'ah@anhuy.com.vn',  -- Email - varchar(50)
    N'Dược phẩm', -- MatHangCungCap - nvarchar(100)
    '555666444',  -- SoTaiKhoan - varchar(20)
    N'Vietcom', -- NganHang - nvarchar(100)
    N'Đang cung cấp'  -- TinhTrangCungCap - nvarchar(50)
    )

INSERT INTO dbo.NHACUNGCAP
VALUES
(   'NCC03',  -- MaNhaCungCap - varchar(15)
    N'CÔNG TY CỔ PHẦN DƯỢC PHẨM TRUNG ƯƠNG CPC1', -- TenNhaCungCap - nvarchar(100)
    N'Số 87 Phố Nguyễn Văn Trỗi, Thanh Xuân, Hà Nội', -- DiaChi - nvarchar(100)
    '02438643327',  -- SoDienThoai - varchar(20)
    'cpc1hanoi@cpc1.com.vn',  -- Email - varchar(50)
    N'Dược phẩm', -- MatHangCungCap - nvarchar(100)
    '999666333',  -- SoTaiKhoan - varchar(20)
    N'Viettin', -- NganHang - nvarchar(100)
    N'Đang cung cấp'  -- TinhTrangCungCap - nvarchar(50)
    )
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
------------------------------ Phiếu nhập hàng
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
INSERT INTO dbo.PHIEUNHAPHANG
VALUES
(   'PNH001',        -- MaPhieuNhapHang - varchar(15)
    'NCC01',        -- MaNhaCungCap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    '5',        -- SoLuongDanhMucHangNhap - varchar(10)
    '1000000',        -- SoTien - varchar(15)
    N'Đã nhập liệu'        -- TinhTrang - nvarchar(50)
    )

INSERT INTO dbo.PHIEUNHAPHANG
VALUES
(   'PNH002',        -- MaPhieuNhapHang - varchar(15)
    'NCC02',        -- MaNhaCungCap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    '10',        -- SoLuongDanhMucHangNhap - varchar(10)
    '1500000',        -- SoTien - varchar(15)
    N'Đã nhập liệu'        -- TinhTrang - nvarchar(50)
    )

INSERT INTO dbo.PHIEUNHAPHANG
VALUES
(   'PNH003',        -- MaPhieuNhapHang - varchar(15)
    'NCC03',        -- MaNhaCungCap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    '15',        -- SoLuongDanhMucHangNhap - varchar(10)
    '2000000',        -- SoTien - varchar(15)
    N'Đã nhập liệu'        -- TinhTrang - nvarchar(50)
    )
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
------------------------------ Chi tiết phiếu nhập hàng
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH001',        -- MaPhieuNhapHang - varchar(15)
    'DP002',        -- MaLoaiDuocPham - varchar(15)
    N'Hộp',       -- DonVi - nvarchar(50)
    'DCYT001',        -- MaHangNhap - varchar(15)
    N'Bom kim tiêm 10cc',       -- TenHangNhap - nvarchar(100)
    N'Dụng cụ y tế',       -- CongDung - nvarchar(50)
    '200000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    50          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH001',        -- MaPhieuNhapHang - varchar(15)
    'DP002',        -- MaLoaiDuocPham - varchar(15)
    N'Hộp',       -- DonVi - nvarchar(50)
    'DCYT002',        -- MaHangNhap - varchar(15)
    N'Bom kim tiêm 100ml',       -- TenHangNhap - nvarchar(100)
    N'Dụng cụ y tế',       -- CongDung - nvarchar(50)
    '150000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    50          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH001',        -- MaPhieuNhapHang - varchar(15)
    'DP002',        -- MaLoaiDuocPham - varchar(15)
    N'Hộp',       -- DonVi - nvarchar(50)
    'DCYT003',        -- MaHangNhap - varchar(15)
    N'Bom kiem tiêm 3cc',       -- TenHangNhap - nvarchar(100)
    N'Dụng cụ y tế',       -- CongDung - nvarchar(50)
    '180000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    50          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH001',        -- MaPhieuNhapHang - varchar(15)
    'DP002',        -- MaLoaiDuocPham - varchar(15)
    N'Bịch',       -- DonVi - nvarchar(50)
    'DCYT004',        -- MaHangNhap - varchar(15)
    N'Băng gạc',       -- TenHangNhap - nvarchar(100)
    N'Dụng cụ y tế',       -- CongDung - nvarchar(50)
    '10000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    100          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH001',        -- MaPhieuNhapHang - varchar(15)
    'DP002',        -- MaLoaiDuocPham - varchar(15)
    N'Bịch',       -- DonVi - nvarchar(50)
    'DCYT005',        -- MaHangNhap - varchar(15)
    N'Bông gòn',       -- TenHangNhap - nvarchar(100)
    N'Dụng cụ y tế',       -- CongDung - nvarchar(50)
    '5000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    100          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH003',        -- MaPhieuNhapHang - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Hộp',       -- DonVi - nvarchar(50)
    'THKH0001',        -- MaHangNhap - varchar(15)
    N'EUGICA',       -- TenHangNhap - nvarchar(100)
    N'Eucalyptol 100mg, Menthol 0,5mg',       -- CongDung - nvarchar(50)
    '40000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    100          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH003',        -- MaPhieuNhapHang - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Hộp',       -- DonVi - nvarchar(50)
    'THKH0002',        -- MaHangNhap - varchar(15)
    N'OTIV',       -- TenHangNhap - nvarchar(100)
    N'Blueberry',       -- CongDung - nvarchar(50)
    '285000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    30          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH003',        -- MaPhieuNhapHang - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Hộp',       -- DonVi - nvarchar(50)
    'THKH0003',        -- MaHangNhap - varchar(15)
    N'Amoxicilin25',       -- TenHangNhap - nvarchar(100)
    N'Amoxicilin 250mg',       -- CongDung - nvarchar(50)
    '25000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    25          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH003',        -- MaPhieuNhapHang - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Hộp',       -- DonVi - nvarchar(50)
    'THKH0004',        -- MaHangNhap - varchar(15)
    N'Loperamide',       -- TenHangNhap - nvarchar(100)
    N'Capsules BP 2mg',       -- CongDung - nvarchar(50)
    '42000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    100          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH003',        -- MaPhieuNhapHang - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Hộp',       -- DonVi - nvarchar(50)
    'THKH0005',        -- MaHangNhap - varchar(15)
    N'Carbogast',       -- TenHangNhap - nvarchar(100)
    N'Vegetable charcoal 400mg',       -- CongDung - nvarchar(50)
    '46000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    30          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH003',        -- MaPhieuNhapHang - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Hộp',       -- DonVi - nvarchar(50)
    'THKH0006',        -- MaHangNhap - varchar(15)
    N'PROBIO',       -- TenHangNhap - nvarchar(100)
    N'Vitamin B1,B2,B3',       -- CongDung - nvarchar(50)
    '15000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    13          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH003',        -- MaPhieuNhapHang - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Hộp',       -- DonVi - nvarchar(50)
    'THKH0007',        -- MaHangNhap - varchar(15)
    N'ACTAPULGITE',       -- TenHangNhap - nvarchar(100)
    N'Attapulgite mormoiron 3g',       -- CongDung - nvarchar(50)
    '102000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    30          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH003',        -- MaPhieuNhapHang - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Hộp',       -- DonVi - nvarchar(50)
    'THKH0008',        -- MaHangNhap - varchar(15)
    N'PMS-DIVACAL',       -- TenHangNhap - nvarchar(100)
    N'Calci D',       -- CongDung - nvarchar(50)
    '65000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    20          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH003',        -- MaPhieuNhapHang - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Hộp',       -- DonVi - nvarchar(50)
    'THKH0009',        -- MaHangNhap - varchar(15)
    N'AC MEXCOLD',       -- TenHangNhap - nvarchar(100)
    N'PARACETAMOL 325mg, CHLORPHENIRAMIN 2mg',       -- CongDung - nvarchar(50)
    '30000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    100          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH003',        -- MaPhieuNhapHang - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Hộp',       -- DonVi - nvarchar(50)
    'THKH0010',        -- MaHangNhap - varchar(15)
    N'PANADOL EXTRA',       -- TenHangNhap - nvarchar(100)
    N'Paracetamol 500mg, Cafein 65mg',       -- CongDung - nvarchar(50)
    '178000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    180          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH003',        -- MaPhieuNhapHang - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Hộp',       -- DonVi - nvarchar(50)
    'THKH0011',        -- MaHangNhap - varchar(15)
    N'Cenflu',       -- TenHangNhap - nvarchar(100)
    N'Paracetamol 650mg',       -- CongDung - nvarchar(50)
    '85000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    100          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH003',        -- MaPhieuNhapHang - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Hộp',       -- DonVi - nvarchar(50)
    'THKH0012',        -- MaHangNhap - varchar(15)
    N'Piromax',       -- TenHangNhap - nvarchar(100)
    N'Piroxicam 10mg',       -- CongDung - nvarchar(50)
    '42000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    100          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH003',        -- MaPhieuNhapHang - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Hộp',       -- DonVi - nvarchar(50)
    'THKH0013',        -- MaHangNhap - varchar(15)
    N'Berocca',       -- TenHangNhap - nvarchar(100)
    N'Vitamin C, B1, B2, B5',       -- CongDung - nvarchar(50)
    '65000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    10          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH003',        -- MaPhieuNhapHang - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Hộp',       -- DonVi - nvarchar(50)
    'THKH0014',        -- MaHangNhap - varchar(15)
    N'Mekocefalor25',       -- TenHangNhap - nvarchar(100)
    N'Mekocefalor 250mg',       -- CongDung - nvarchar(50)
    '29000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    12          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH003',        -- MaPhieuNhapHang - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Hộp',       -- DonVi - nvarchar(50)
    'THKH0015',        -- MaHangNhap - varchar(15)
    N'Mekocefalor12',       -- TenHangNhap - nvarchar(100)
    N'Mekocefalor 125mg',       -- CongDung - nvarchar(50)
    '24000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    12          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH002',        -- MaPhieuNhapHang - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'Bình',       -- DonVi - nvarchar(50)
    'DPSC0001',        -- MaHangNhap - varchar(15)
    N'Ringer lactate',       -- TenHangNhap - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(50)
    '75000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    50          -- SoLuongNhap - int
    )

INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH002',        -- MaPhieuNhapHang - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'Bình',       -- DonVi - nvarchar(50)
    'DPSC0002',        -- MaHangNhap - varchar(15)
    N'NaCl 0,9%',       -- TenHangNhap - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(50)
    '60000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    50          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH002',        -- MaPhieuNhapHang - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'Bình',       -- DonVi - nvarchar(50)
    'DPSC0003',        -- MaHangNhap - varchar(15)
    N'NaCl 7,5%',       -- TenHangNhap - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(50)
    '55000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    50          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH002',        -- MaPhieuNhapHang - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'Bình',       -- DonVi - nvarchar(50)
    'DPSC0004',        -- MaHangNhap - varchar(15)
    N'Albumin 4%',       -- TenHangNhap - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(50)
    '45000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    50          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH002',        -- MaPhieuNhapHang - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'Bình',       -- DonVi - nvarchar(50)
    'DPSC0005',        -- MaHangNhap - varchar(15)
    N'Albumin 20%',       -- TenHangNhap - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(50)
    '60000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    50          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH002',        -- MaPhieuNhapHang - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'Bình',       -- DonVi - nvarchar(50)
    'DPSC0006',        -- MaHangNhap - varchar(15)
    N'Dextran (Rheomacrode)',       -- TenHangNhap - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(50)
    '50000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    50          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH002',        -- MaPhieuNhapHang - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'Bình',       -- DonVi - nvarchar(50)
    'DPSC0007',        -- MaHangNhap - varchar(15)
    N'Dextran (Hemodex)',       -- TenHangNhap - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(50)
    '70000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    50          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH002',        -- MaPhieuNhapHang - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'Lọ',       -- DonVi - nvarchar(50)
    'DPSC0008',        -- MaHangNhap - varchar(15)
    N'Mimosa',       -- TenHangNhap - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(50)
    '60000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    50          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH002',        -- MaPhieuNhapHang - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'Lọ',       -- DonVi - nvarchar(50)
    'DPSC0009',        -- MaHangNhap - varchar(15)
    N'Sanbutamol2',       -- TenHangNhap - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(50)
    '12000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    100          -- SoLuongNhap - int
    )
INSERT dbo.CHITIETPHIEUNHAP

VALUES
(   'PNH002',        -- MaPhieuNhapHang - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'Lọ',       -- DonVi - nvarchar(50)
    'DPSC0010',        -- MaHangNhap - varchar(15)
    N'Duphalac',       -- TenHangNhap - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(50)
    '85000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    20          -- SoLuongNhap - int
    )
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
------------------------------ Thuốc khám
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------

INSERT dbo.THUOCKHAM

VALUES
(   'THKH0001',        -- MaThuocKham - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'EUGICA',       -- TenThuocKham - nvarchar(100)
    N'Eucalyptol 100mg, Menthol 0,5mg',       -- CongDung - nvarchar(100)
    N'Hộp',       -- DonVi - nvarchar(50)
    '40000',        -- GiaThuocNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '45000',        -- GiaThuocBan - varchar(15)
    100          -- SoLuongCon - int
    )
INSERT dbo.THUOCKHAM

VALUES
(   'THKH0002',        -- MaThuocKham - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'OTIV',       -- TenThuocKham - nvarchar(100)
    N'Blueberry',       -- CongDung - nvarchar(100)
    N'Hộp',       -- DonVi - nvarchar(50)
    '285000',        -- GiaThuocNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '330000',        -- GiaThuocBan - varchar(15)
    30          -- SoLuongCon - int
    )
INSERT dbo.THUOCKHAM

VALUES
(   'THKH0003',        -- MaThuocKham - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Amoxicilin25',       -- TenThuocKham - nvarchar(100)
    N'Amoxicilin 250mg',       -- CongDung - nvarchar(100)
    N'Hộp',       -- DonVi - nvarchar(50)
    '25000',        -- GiaThuocNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '29425',        -- GiaThuocBan - varchar(15)
    25          -- SoLuongCon - int
    )
INSERT dbo.THUOCKHAM

VALUES
(   'THKH0004',        -- MaThuocKham - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Loperamide',       -- TenThuocKham - nvarchar(100)
    N'Capsules BP 2mg',       -- CongDung - nvarchar(100)
    N'Hộp',       -- DonVi - nvarchar(50)
    '42000',        -- GiaThuocNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '49434',        -- GiaThuocBan - varchar(15)
    100          -- SoLuongCon - int
    )
INSERT dbo.THUOCKHAM

VALUES
(   'THKH0005',        -- MaThuocKham - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Carbogast',       -- TenThuocKham - nvarchar(100)
    N'Vegetable charcoal 400mg',       -- CongDung - nvarchar(100)
    N'Hộp',       -- DonVi - nvarchar(50)
    '46000',        -- GiaThuocNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '54142',        -- GiaThuocBan - varchar(15)
    30          -- SoLuongCon - int
    )
INSERT dbo.THUOCKHAM

VALUES
(   'THKH0006',        -- MaThuocKham - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'PROBIO',       -- TenThuocKham - nvarchar(100)
    N'Vitamin B1,B2,B3',       -- CongDung - nvarchar(100)
    N'Hộp',       -- DonVi - nvarchar(50)
    '15000',        -- GiaThuocNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '18000',        -- GiaThuocBan - varchar(15)
    13          -- SoLuongCon - int
    )
INSERT dbo.THUOCKHAM

VALUES
(   'THKH0007',        -- MaThuocKham - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'ACTAPULGITE',       -- TenThuocKham - nvarchar(100)
    N'Attapulgite mormoiron 3g',       -- CongDung - nvarchar(100)
    N'Hộp',       -- DonVi - nvarchar(50)
    '102000',        -- GiaThuocNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '115000',        -- GiaThuocBan - varchar(15)
    30          -- SoLuongCon - int
    )
INSERT dbo.THUOCKHAM

VALUES
(   'THKH0008',        -- MaThuocKham - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'PMS-DIVACAL',       -- TenThuocKham - nvarchar(100)
    N'Calci D',       -- CongDung - nvarchar(100)
    N'Hộp',       -- DonVi - nvarchar(50)
    '65000',        -- GiaThuocNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '73500',        -- GiaThuocBan - varchar(15)
    20          -- SoLuongCon - int
    )
INSERT dbo.THUOCKHAM

VALUES
(   'THKH0009',        -- MaThuocKham - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'AC MEXCOLD',       -- TenThuocKham - nvarchar(100)
    N'PARACETAMOL 325mg, CHLORPHENIRAMIN 2mg',       -- CongDung - nvarchar(100)
    N'Hộp',       -- DonVi - nvarchar(50)
    '30000',        -- GiaThuocNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '35000',        -- GiaThuocBan - varchar(15)
    100          -- SoLuongCon - int
    )
INSERT dbo.THUOCKHAM

VALUES
(   'THKH0010',        -- MaThuocKham - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'PANADOL EXTRA',       -- TenThuocKham - nvarchar(100)
    N'Paracetamol 500mg, Cafein 65mg',       -- CongDung - nvarchar(100)
    N'Hộp',       -- DonVi - nvarchar(50)
    '178000',        -- GiaThuocNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '198000',        -- GiaThuocBan - varchar(15)
    180          -- SoLuongCon - int
    )
INSERT dbo.THUOCKHAM

VALUES
(   'THKH0011',        -- MaThuocKham - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Cenflu',       -- TenThuocKham - nvarchar(100)
    N'Paracetamol 650mg',       -- CongDung - nvarchar(100)
    N'Hộp',       -- DonVi - nvarchar(50)
    '85000',        -- GiaThuocNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '100045',        -- GiaThuocBan - varchar(15)
    100          -- SoLuongCon - int
    )
INSERT dbo.THUOCKHAM

VALUES
(   'THKH0012',        -- MaThuocKham - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Piromax',       -- TenThuocKham - nvarchar(100)
    N'Piroxicam 10mg',       -- CongDung - nvarchar(100)
    N'Hộp',       -- DonVi - nvarchar(50)
    '42000',        -- GiaThuocNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '49434',        -- GiaThuocBan - varchar(15)
    100          -- SoLuongCon - int
    )
INSERT dbo.THUOCKHAM

VALUES
(   'THKH0013',        -- MaThuocKham - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Berocca',       -- TenThuocKham - nvarchar(100)
    N'Vitamin C, B1, B2, B5',       -- CongDung - nvarchar(100)
    N'Hộp',       -- DonVi - nvarchar(50)
    '65000',        -- GiaThuocNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '76505',        -- GiaThuocBan - varchar(15)
    10          -- SoLuongCon - int
    )
INSERT dbo.THUOCKHAM

VALUES
(   'THKH0014',        -- MaThuocKham - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Mekocefalor25',       -- TenThuocKham - nvarchar(100)
    N'Mekocefalor 250mg',       -- CongDung - nvarchar(100)
    N'Hộp',       -- DonVi - nvarchar(50)
    '29000',        -- GiaThuocNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '34133',        -- GiaThuocBan - varchar(15)
    12          -- SoLuongCon - int
    )
INSERT dbo.THUOCKHAM

VALUES
(   'THKH0015',        -- MaThuocKham - varchar(15)
    'DP001',        -- MaLoaiDuocPham - varchar(15)
    N'Mekocefalor12',       -- TenThuocKham - nvarchar(100)
    N'Mekocefalor 125mg',       -- CongDung - nvarchar(100)
    N'Hộp',       -- DonVi - nvarchar(50)
    '24000',        -- GiaThuocNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '28248',        -- GiaThuocBan - varchar(15)
    12          -- SoLuongCon - int
    )
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
------------------------------ Thuốc khám
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
INSERT dbo.DUOCPHAMDVYTESOCUU
VALUES
(   'DPSC0001',        -- MaDuocPhamDVSoCuu - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'Ringer lactate',       -- TenDuocPham - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(200)
    N'Bình',       -- DonVi - nvarchar(50)
    '75000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '85000',        -- GiaBan - varchar(15)
    50          -- SoLuongCon - int
    )
INSERT dbo.DUOCPHAMDVYTESOCUU
VALUES
(   'DPSC0002',        -- MaDuocPhamDVSoCuu - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'NaCl 0,9%',       -- TenDuocPham - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(200)
    N'Bình',       -- DonVi - nvarchar(50)
    '60000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '75000',        -- GiaBan - varchar(15)
    50          -- SoLuongCon - int
    )
INSERT dbo.DUOCPHAMDVYTESOCUU
VALUES
(   'DPSC0003',        -- MaDuocPhamDVSoCuu - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'NaCl 7,5%',       -- TenDuocPham - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(200)
    N'Bình',       -- DonVi - nvarchar(50)
    '55000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '70000',        -- GiaBan - varchar(15)
    50          -- SoLuongCon - int
    )
INSERT dbo.DUOCPHAMDVYTESOCUU
VALUES
(   'DPSC0004',        -- MaDuocPhamDVSoCuu - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'Albumin 4%',       -- TenDuocPham - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(200)
    N'Bình',       -- DonVi - nvarchar(50)
    '45000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '60000',        -- GiaBan - varchar(15)
    50          -- SoLuongCon - int
    )
INSERT dbo.DUOCPHAMDVYTESOCUU
VALUES
(   'DPSC0005',        -- MaDuocPhamDVSoCuu - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'Albumin 20%',       -- TenDuocPham - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(200)
    N'Bình',       -- DonVi - nvarchar(50)
    '60000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '75000',        -- GiaBan - varchar(15)
    50          -- SoLuongCon - int
    )
INSERT dbo.DUOCPHAMDVYTESOCUU
VALUES
(   'DPSC0006',        -- MaDuocPhamDVSoCuu - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'Dextran (Rheomacrode)',       -- TenDuocPham - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(200)
    N'Bình',       -- DonVi - nvarchar(50)
    '50000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '65000',        -- GiaBan - varchar(15)
    50          -- SoLuongCon - int
    )
INSERT dbo.DUOCPHAMDVYTESOCUU
VALUES
(   'DPSC0007',        -- MaDuocPhamDVSoCuu - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'Dextran (Hemodex)',       -- TenDuocPham - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(200)
    N'Bình',       -- DonVi - nvarchar(50)
    '70000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '85000',        -- GiaBan - varchar(15)
    50          -- SoLuongCon - int
    )
INSERT dbo.DUOCPHAMDVYTESOCUU
VALUES
(   'DPSC0008',        -- MaDuocPhamDVSoCuu - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'Mimosa',       -- TenDuocPham - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(200)
    N'Lọ',       -- DonVi - nvarchar(50)
    '60000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '70620',        -- GiaBan - varchar(15)
    50          -- SoLuongCon - int
    )
INSERT dbo.DUOCPHAMDVYTESOCUU
VALUES
(   'DPSC0009',        -- MaDuocPhamDVSoCuu - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'Sanbutamol2',       -- TenDuocPham - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(200)
    N'Lọ',       -- DonVi - nvarchar(50)
    '12000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '14124',        -- GiaBan - varchar(15)
    100          -- SoLuongCon - int
    )
INSERT dbo.DUOCPHAMDVYTESOCUU
VALUES
(   'DPSC0010',        -- MaDuocPhamDVSoCuu - varchar(15)
    'DP003',        -- MaLoaiDuocPham - varchar(15)
    N'Duphalac',       -- TenDuocPham - nvarchar(100)
    N'Phục hồi sức khỏe',       -- CongDung - nvarchar(200)
    N'Lọ',       -- DonVi - nvarchar(50)
    '85000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng',       -- TinhTrangConSD - nvarchar(50)
    '100045',        -- GiaBan - varchar(15)
    20          -- SoLuongCon - int
    )
	--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
------------------------------ Dụng cụ y tế
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
INSERT dbo.DUNGCUYTE

VALUES
(   'DCYT001',        -- MaDungCuYTe - varchar(15)
    'DP002',        -- MaLoaiDuocPham - varchar(15)
    N'Bom kim tiêm 10cc',       -- TenDungCuYTe - nvarchar(100)
    N'Dụng cụ y tế',       -- CongDung - nvarchar(200)
    N'Hộp',       -- DonVi - nvarchar(50)
    '200000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng'        -- TinhTrangSuDung - nvarchar(50)
    )
INSERT dbo.DUNGCUYTE

VALUES
(   'DCYT002',        -- MaDungCuYTe - varchar(15)
    'DP002',        -- MaLoaiDuocPham - varchar(15)
    N'Bom kim tiêm 100ml',       -- TenDungCuYTe - nvarchar(100)
    N'Dụng cụ y tế',       -- CongDung - nvarchar(200)
    N'Hộp',       -- DonVi - nvarchar(50)
    '150000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng'        -- TinhTrangSuDung - nvarchar(50)
    )
INSERT dbo.DUNGCUYTE

VALUES
(   'DCYT003',        -- MaDungCuYTe - varchar(15)
    'DP002',        -- MaLoaiDuocPham - varchar(15)
    N'Bom kiem tiêm 3cc',       -- TenDungCuYTe - nvarchar(100)
    N'Dụng cụ y tế',       -- CongDung - nvarchar(200)
    N'Hộp',       -- DonVi - nvarchar(50)
    '180000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng'        -- TinhTrangSuDung - nvarchar(50)
    )
INSERT dbo.DUNGCUYTE

VALUES
(   'DCYT004',        -- MaDungCuYTe - varchar(15)
    'DP002',        -- MaLoaiDuocPham - varchar(15)
    N'Băng gạc',       -- TenDungCuYTe - nvarchar(100)
    N'Dụng cụ y tế',       -- CongDung - nvarchar(200)
    N'Bịch',       -- DonVi - nvarchar(50)
    '10000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng'        -- TinhTrangSuDung - nvarchar(50)
    )
INSERT dbo.DUNGCUYTE

VALUES
(   'DCYT005',        -- MaDungCuYTe - varchar(15)
    'DP002',        -- MaLoaiDuocPham - varchar(15)
    N'Bông gòn',       -- TenDungCuYTe - nvarchar(100)
    N'Dụng cụ y tế',       -- CongDung - nvarchar(200)
    N'Bịch',       -- DonVi - nvarchar(50)
    '5000',        -- GiaNhap - varchar(15)
    '2019/06/01', -- NgayNhap - date
    N'Còn sử  dụng'        -- TinhTrangSuDung - nvarchar(50)
    )

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



