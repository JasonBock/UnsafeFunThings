| Method            | Mean      | Error     | StdDev    | Code Size | Allocated |
|------------------ |----------:|----------:|----------:|----------:|----------:|
| CastUsingCSharp   | 0.8693 ns | 0.0045 ns | 0.0042 ns |      62 B |         - |
| CastUsingUnsafeAs | 0.7412 ns | 0.0021 ns | 0.0020 ns |       5 B |         - |

```assembly
; UnsafeFunThings.UsingUnsafeAs.CastingObjects.CastUsingCSharp()
       sub       rsp,28
       mov       rdx,[rcx+8]
       mov       rax,rdx
       test      rax,rax
       je        short 000000000000133F
       mov       rcx,offset MT_UnsafeFunThings.UsingUnsafeAs.TargetType
       cmp       [rax],rcx
       jne       short 0000000000001344
M00_L00:
       add       rsp,28
       ret
M00_L01:
       call      000000000000B110
       int       3
; Total bytes of code 42
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.ChkCastClass(Void*, System.Object)
       test      rdx,rdx
       je        short 000000000000B11A
       cmp       [rdx],rcx
       jne       short 000000000000B11E
M01_L00:
       mov       rax,rdx
       ret
M01_L01:
       jmp       qword ptr [0FE40]; System.Runtime.CompilerServices.CastHelpers.ChkCastClassSpecial(Void*, System.Object)
; Total bytes of code 20
```

```assembly
; UnsafeFunThings.UsingUnsafeAs.CastingObjects.CastUsingUnsafeAs()
       mov       rax,[rcx+8]
       ret
; Total bytes of code 5
```