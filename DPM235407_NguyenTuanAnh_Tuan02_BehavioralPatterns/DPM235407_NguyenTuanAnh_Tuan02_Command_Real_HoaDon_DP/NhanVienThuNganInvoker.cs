using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_Tuan02_Command_Real_HoaDon_DP
{
    // Invoker: Nhân viên thu ngân quản lý các thao tác và lịch sử Undo
    public class NhanVienThuNganInvoker
    {
        private readonly Stack<IHoaDonCommand> _lichSuLenh = new();

        public void ThucHien(IHoaDonCommand lenh)
        {
            lenh.Execute();
            _lichSuLenh.Push(lenh);
        }

        public void HoanTac()
        {
            if (_lichSuLenh.Count > 0)
            {
                var lenhCanUndo = _lichSuLenh.Pop();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\n<< BẮT ĐẦU HOÀN TÁC THAO TÁC: {lenhCanUndo.GetMoTa()} >>");
                Console.ResetColor();
                lenhCanUndo.Undo();
            }
            else
            {
                Console.WriteLine("   [THÔNG BÁO] Không còn thao tác nào để hoàn tác.");
            }
        }

        public void InLichSu()
        {
            Console.WriteLine("\n[LỊCH SỬ THAO TÁC ĐÃ THỰC HIỆN]");
            int i = 1;
            foreach (var cmd in _lichSuLenh)
            {
                Console.WriteLine($"   {i++}. {cmd.GetMoTa()}");
            }
        }
    }
}
