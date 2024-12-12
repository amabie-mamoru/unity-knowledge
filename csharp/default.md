# System.Collections.Generic.Dictionary をはじめとする初期値の話

Dictionary に限らず全般的に言えることだが、 Dictionary で宣言しただけの変数はコンパイルエラーになり、 default で指定した場合は null となり、 new して空の初期値を与えると空の Dictionary が返る

```cs
// ----------
// Dictionary
// ----------
Dictionary<string, int> dict = default;
// Rider Warning: Expression is always true
Debug.Log($"dict: {dict == null}");

Dictionary<string, int> dict2;
// Rider Error: Local variable 'dict2'  might not be initialized before accessing
// Unity Compile Error: CS0165: Use of unassigned local variable 'dict2'
// Debug.Log($"dict2: {dict2 == null}");

Dictionary<string, int> dict3 = new Dictionary<string, int>();
// Rider Warning: Expression is always false
Debug.Log($"dict: {dict3 == null}");
```

# 参考コード

その他を含む参考コード

```cs
using System.Collections.Generic;
using UnityEngine;

public class DefaultSample : MonoBehaviour
{
    void Awake()
    {
        // int / string
        int intValue = default;
        // Rider Warning: The result of the expression is always 'false' because a value of 'int' is never equal to 'null' of type 'int'?
        Debug.Log($"int: {intValue == null}");
        int intValue2;
        // Rider Error: Local variable 'intValue2'  might not be initialized before accessing
        // Unity Compile Error: CS0165: Use of unassigned local variable 'intValue2'
        // Debug.Log($"int: {intValue2 == null}");

        string stringValue = default;
        // Rider Warning: Expression is always true
        Debug.Log($"string: {stringValue == null}");
        string stringValue2;
        // Rider Error: Local variable 'intValue2'  might not be initialized before accessing
        // Unity Compile Error: CS0165: Use of unassigned local variable 'stringValue2'
        // Debug.Log($"string: {stringValue2 == null}");

        // ----------
        // List
        // ----------
        List<int> list = default;
        // Rider Warning: Expression is always true
        Debug.Log($"list: {list == null}");
        List<int> list2;
        // Rider Error: Local variable 'list2'  might not be initialized before accessing
        // Unity Compile Error: CS0165: Use of unassigned local variable 'list2'
        // Debug.Log($"list2: {list2 == null}");

        // ----------
        // Dictionary
        // ----------
        Dictionary<string, int> dict = default;
        // Rider Warning: Expression is always true
        Debug.Log($"dict: {dict == null}");
        Dictionary<string, int> dict2;
        // Rider Error: Local variable 'dict2'  might not be initialized before accessing
        // Unity Compile Error: CS0165: Use of unassigned local variable 'dict2'
        // Debug.Log($"dict2: {dict2 == null}");

        // ----------
        // Class
        // ----------
        NewClass newClass = default;
        // Rider Warning: Expression is always true
        Debug.Log($"class: {newClass == null}");
        NewClass newClass2;
        // Rider Error: Local variable 'newClass2'  might not be initialized before accessing
        // Unity Compile Error: CS0165: Use of unassigned local variable 'newClass2'
        // Debug.Log($"class2: {newClass2 == null}");

        // ----------
        // Struct
        // ----------
        NewStruct newStruct = default;
        // Rider Error: Cannot apply operator '==' to operands of type 'NewStruct' and 'null'
        // Unity Compile Error: CS0019: Operator '==' cannot be applied to operands of type 'NewStruct' and '<null>'
        // Debug.Log($"struct: {newStruct == null}");
        NewStruct newStruct2;
        // Rider Error: Cannot apply operator '==' to operands of type 'NewStruct' and 'null'
        // Unity Compile Error: CS0019: Operator '==' cannot be applied to operands of type 'NewStruct' and '<null>'
        // Debug.Log($"struct: {newStruct2 == null}");
    }
}

public class NewClass
{

}

public struct NewStruct
{

}
```
