using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class SaveAndLoadSystem
{
    public static void Save(LichSuBienDong ls)
    {
        DataNeedSaved data = new DataNeedSaved(ls);
        // Debug.Log(data.getLichSuBienDong()[0].get);

        // Chuyển đổi đối tượng GameData thành chuỗi JSON
        string json = JsonUtility.ToJson(data);

        // Xác định đường dẫn lưu trữ (thư mục persistent data)
        string path = Path.Combine(Application.persistentDataPath, "TienVaBienDong.json");
        // path = "Data/TienVaBienDong.json";
        // string path = "TienVaBienDong.json";
        // Lưu chuỗi JSON vào file
        File.WriteAllText(path, json);
        // Load();

    }
    public static void ResetData()
    {
        string path = Path.Combine(Application.persistentDataPath, "TienVaBienDong.json");
        // path = "Data/TienVaBienDong.json";
        // Kiểm tra xem thư mục có tồn tại không
        if (Directory.Exists(path))
        {
            // Xóa tất cả các tệp và thư mục trong thư mục persistentDataPath
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();  // Xóa tệp
            }

            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                dir.Delete(true);  // Xóa thư mục và nội dung bên trong
            }

            Debug.Log("All data cleared from persistentDataPath.");
        }
        else
        {
            Debug.LogWarning("Directory does not exist.");
        }
    }
    public static DataNeedSaved Load()
    {
        // return null;
        string path = Path.Combine(Application.persistentDataPath, "TienVaBienDong.json");
        // path = "Data/TienVaBienDong.json";
        // string path = "TienVaBienDong.json";
        // Kiểm tra nếu file tồn tại
        if (File.Exists(path))
        {
            // Đọc chuỗi JSON từ file
            string json = File.ReadAllText(path);

            // Chuyển chuỗi JSON thành đối tượng GameData
            DataNeedSaved data = JsonUtility.FromJson<DataNeedSaved>(json);
            // Debug.Log(data.getMoney());
            // Debug.Log(data.getLichSuBienDong().Count);
            // Debug.Log("Data loaded from: " + path);
            return data;
        }

        Debug.LogWarning("No data file found.");
        return null;
    }
    public static void SavePhanLoai(PhanLoaiTien pl)
    {
        // DataNeedSaved data = new DataNeedSaved(ls);
        DataPhanLoai data = new DataPhanLoai(pl);

        // Chuyển đổi đối tượng GameData thành chuỗi JSON
        string json = JsonUtility.ToJson(data);

        // Xác định đường dẫn lưu trữ (thư mục persistent data)
        // string path = Path.Combine(Application.persistentDataPath, "TienVaBienDong.json");
        string path = Path.Combine(Application.persistentDataPath, "PhanLoai.json"); ;
        // path = "Data/PhanLoai.json";
        // Lưu chuỗi JSON vào file
        File.WriteAllText(path, json);
        // Load();

    }
    public static void SavePhanLoai(DataPhanLoai pl)
    {
        // DataNeedSaved data = new DataNeedSaved(ls);
        DataPhanLoai data = pl;

        // Chuyển đổi đối tượng GameData thành chuỗi JSON
        string json = JsonUtility.ToJson(data);

        // Xác định đường dẫn lưu trữ (thư mục persistent data)
        // string path = Path.Combine(Application.persistentDataPath, "TienVaBienDong.json");
        string path = Path.Combine(Application.persistentDataPath, "PhanLoai.json");
        // path = "Data/PhanLoai.json";
        // Lưu chuỗi JSON vào file
        File.WriteAllText(path, json);
        // Load();

    }
    public static DataPhanLoai LoadPhanLoai()
    {
        // return null;
        // string path = Path.Combine(Application.persistentDataPath, "TienVaBienDong.json");
        string path = Path.Combine(Application.persistentDataPath, "PhanLoai.json"); ;
        // path = "Data/PhanLoai.json";
        // Kiểm tra nếu file tồn tại
        if (File.Exists(path))
        {
            // Đọc chuỗi JSON từ file
            string json = File.ReadAllText(path);

            // Chuyển chuỗi JSON thành đối tượng GameData
            DataPhanLoai data = JsonUtility.FromJson<DataPhanLoai>(json);
            // Debug.Log(data.getMoney());
            // Debug.Log(data.getLichSuBienDong().Count);
            // Debug.Log("Data loaded from: " + path);
            return data;
        }

        Debug.LogWarning("No data file found.");
        return null;
    }

    public static void SaveKeHoach(KeHoach kh)
    {
        // DataNeedSaved data = new DataNeedSaved(ls);
        KeHoach data = kh;

        // Chuyển đổi đối tượng GameData thành chuỗi JSON
        string json = JsonUtility.ToJson(data);

        // Xác định đường dẫn lưu trữ (thư mục persistent data)

        string path = Path.Combine(Application.persistentDataPath, "KeHoach.json");
        // path = "Data/KeHoach.json";

        // Lưu chuỗi JSON vào file
        File.WriteAllText(path, json);
        // Load();

    }
    public static KeHoach LoadKeHoach()
    {
        // return null;
        // string path = Path.Combine(Application.persistentDataPath, "TienVaBienDong.json");
        string path = Path.Combine(Application.persistentDataPath, "KeHoach.json");
        // path = "Data/KeHoach.json";
        // string path = "./KeHoach.json";
        // Kiểm tra nếu file tồn tại
        if (File.Exists(path))
        {
            // Đọc chuỗi JSON từ file
            string json = File.ReadAllText(path);

            // Chuyển chuỗi JSON thành đối tượng GameData
            KeHoach data = JsonUtility.FromJson<KeHoach>(json);
            // Debug.Log(data.getMoney());
            // Debug.Log(data.getLichSuBienDong().Count);
            // Debug.Log("Data loaded from: " + path);
            return data;
        }

        Debug.LogWarning("No data file found.");
        return null;
    }
    public static void SaveKhoanVay(KhoanVay khoanVay)
    {
        // DataNeedSaved data = new DataNeedSaved(ls);
        KhoanVay data = khoanVay;

        // Chuyển đổi đối tượng GameData thành chuỗi JSON
        string json = JsonUtility.ToJson(data);

        // Xác định đường dẫn lưu trữ (thư mục persistent data)
        // string path = Path.Combine(Application.persistentDataPath, "TienVaBienDong.json");
        string path = Path.Combine(Application.persistentDataPath, "KhoanVay.json");
        // path = "Data/PhanLoai.json";
        // Lưu chuỗi JSON vào file
        File.WriteAllText(path, json);
        // Load();

    }
    public static KhoanVay LoadKhoanVay()
    {
        // return null;
        // string path = Path.Combine(Application.persistentDataPath, "TienVaBienDong.json");
        string path = Path.Combine(Application.persistentDataPath, "KhoanVay.json"); ;
        // path = "Data/PhanLoai.json";
        // Kiểm tra nếu file tồn tại
        if (File.Exists(path))
        {
            // Đọc chuỗi JSON từ file
            string json = File.ReadAllText(path);

            // Chuyển chuỗi JSON thành đối tượng GameData
            KhoanVay data = JsonUtility.FromJson<KhoanVay>(json);
            // Debug.Log(data.getMoney());
            // Debug.Log(data.getLichSuBienDong().Count);
            // Debug.Log("Data loaded from: " + path);
            return data;
        }

        Debug.LogWarning("No data file found.");
        return null;
    }
    public static void SaveThongTinKhoanVay(ThongTinKhoanVay khoanVay)
    {
        // DataNeedSaved data = new DataNeedSaved(ls);
        ThongTinKhoanVay data = khoanVay;

        // Chuyển đổi đối tượng GameData thành chuỗi JSON
        string json = JsonUtility.ToJson(data);

        // Xác định đường dẫn lưu trữ (thư mục persistent data)
        // string path = Path.Combine(Application.persistentDataPath, "TienVaBienDong.json");
        string path = Path.Combine(Application.persistentDataPath, "ThongTinKhoanVay.json");
        // path = "Data/PhanLoai.json";
        // Lưu chuỗi JSON vào file
        File.WriteAllText(path, json);
        // Load();

    }
    public static ThongTinKhoanVay LoadThongTinKhoanVay()
    {
        // return null;
        // string path = Path.Combine(Application.persistentDataPath, "TienVaBienDong.json");
        string path = Path.Combine(Application.persistentDataPath, "ThongTinKhoanVay.json"); ;
        // path = "Data/PhanLoai.json";
        // Kiểm tra nếu file tồn tại
        if (File.Exists(path))
        {
            // Đọc chuỗi JSON từ file
            string json = File.ReadAllText(path);

            // Chuyển chuỗi JSON thành đối tượng GameData
            ThongTinKhoanVay data = JsonUtility.FromJson<ThongTinKhoanVay>(json);
            // Debug.Log(data.getMoney());
            // Debug.Log(data.getLichSuBienDong().Count);
            // Debug.Log("Data loaded from: " + path);
            return data;
        }

        Debug.LogWarning("No data file found.");
        return null;
    }
    public static string CopyAllDatas()
    {
        string s = "";
        string prePath = Application.persistentDataPath;
        string path;
        // tổng tiền và biến động
        try
        {
            path = Path.Combine(prePath, "TienVaBienDong.json");
            s += File.ReadAllText(path);
        }
        catch (FileNotFoundException)
        {
            s += "";
        }
        s += "\n";
        // phân loại
        try
        {
            path = Path.Combine(prePath, "PhanLoai.json");
            s += File.ReadAllText(path);
        }
        catch (FileNotFoundException)
        {
            s += "";
        }
        s += "\n";
        // kế hoạch
        try
        {
            path = Path.Combine(prePath, "KeHoach.json");
            s += File.ReadAllText(path);
        }
        catch (FileNotFoundException)
        {
            s += "";
        }
        s += "\n";
        // khoản vay
        try
        {
            path = Path.Combine(prePath, "KhoanVay.json");
            s += File.ReadAllText(path);
        }
        catch (FileNotFoundException)
        {
            s += "";
        }
        s += "\n";
        // thông tin khoản vay
        try
        {
            path = Path.Combine(prePath, "ThongTinKhoanVay.json");
            s += File.ReadAllText(path);
        }
        catch (FileNotFoundException)
        {
            s += "";
        }
        return s;
    }
    public static void LoadAllDatas(string s)
    {
        string prePath = Application.persistentDataPath;
        string path;
        string[] arrayString = s.Split('\n');
        // tiền và biến động
        path = Path.Combine(prePath, "TienVaBienDong.json");
        File.WriteAllText(path, arrayString[0]);
        // tiền và biến động
        path = Path.Combine(prePath, "PhanLoai.json");
        File.WriteAllText(path, arrayString[1]);
        // tiền và biến động
        path = Path.Combine(prePath, "KeHoach.json");
        File.WriteAllText(path, arrayString[2]);
        // tiền và biến động
        path = Path.Combine(prePath, "KhoanVay.json");
        File.WriteAllText(path, arrayString[3]);
        // tiền và biến động
        path = Path.Combine(prePath, "ThongTinKhoanVay.json");
        File.WriteAllText(path, arrayString[4]);
    }
    public static void DeleteAllDatas()
    {
        string prePath = Application.persistentDataPath;
        string path;
        // tiền và biến động
        path = Path.Combine(prePath, "TienVaBienDong.json");
        File.Delete(path);
        // tiền và biến động
        path = Path.Combine(prePath, "PhanLoai.json");
        File.Delete(path);
        // tiền và biến động
        path = Path.Combine(prePath, "KeHoach.json");
        File.Delete(path);
        // tiền và biến động
        path = Path.Combine(prePath, "KhoanVay.json");
        File.Delete(path);
        // tiền và biến động
        path = Path.Combine(prePath, "ThongTinKhoanVay.json");
        File.Delete(path);
    }
}
