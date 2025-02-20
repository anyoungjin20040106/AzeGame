using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System;
public static class Session
{
    //문제 데이터들
    private static List<string> _rows;
    //문제 데이터
    public static string question{
        get{
            return _rows[selectLevel].Split("\t")[0];
        }
    }
    public static string answer{
        get{
            return _rows[selectLevel].Split("\t")[1];
        }

    }
    public static string explanation{
        get{
            return _rows[selectLevel].Split("\t")[2];
        }

    }
    public static string hint{
        get{
            return _rows[selectLevel].Split("\t")[3];
        }

    }
    //문제 데이터 순번의 이름
    public static IEnumerator setRows()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(ENV.sheet))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log($"데이터\n{www.downloadHandler.text}");
                _rows = new List<string>(www.downloadHandler.text.Split("\n"));
            }
            else
            {
                Debug.Log(www.result);
                _rows = new List<string>();
            }
        }
    }
    //현제 레벨을 의미하는 프로퍼티
    public static int level
    {
        get
        {
            if (!File.Exists(ENV.path)){
                File.WriteAllText(ENV.path, Convert.ToBase64String(Encoding.UTF8.GetBytes("0")), Encoding.UTF8);
                return 0;
            }
            string data = File.ReadAllText(ENV.path, Encoding.UTF8);
            try{
            return int.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(data)));
            }catch(Exception){
                File.WriteAllText(ENV.path, Convert.ToBase64String(Encoding.UTF8.GetBytes("0")), Encoding.UTF8);
                return 0;
            }
        }
        set
        {
            File.WriteAllText(ENV.path, Convert.ToBase64String(Encoding.UTF8.GetBytes(value.ToString())));
        }
    }
    //현제 선택한 레벨
    public static int selectLevel;
    //성공 유무
    static bool _isSuccess;
    public static void setSuccess (string answer){
        _isSuccess =answer==Session.answer;
    }
    public static bool isSuccess {
        get{
            return _isSuccess;
        }
    }
    public static int maxLevel{
        get{
            return _rows.Count-1;
        }
    }


}