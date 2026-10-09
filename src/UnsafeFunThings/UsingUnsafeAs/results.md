# .NET 10

| Method            | Mean      | Error     | StdDev    | Code Size | Allocated |
|------------------ |----------:|----------:|----------:|----------:|----------:|
| CastUsingCSharp   | 0.5096 ns | 0.0316 ns | 0.0296 ns |      62 B |         - |
| CastUsingUnsafeAs | 0.3673 ns | 0.0103 ns | 0.0096 ns |       5 B |         - |

## .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v3 (Job: DefaultJob)

```assembly
; UnsafeFunThings.UsingUnsafeAs.CastingObjects.CastUsingCSharp()
       sub       rsp,28
       mov       rdx,[rcx+8]
       mov       rax,rdx
       test      rax,rax
       je        short M00_L00
       mov       rcx,offset MT_UnsafeFunThings.UsingUnsafeAs.TargetType
       cmp       [rax],rcx
       jne       short M00_L01
M00_L00:
       add       rsp,28
       ret
M00_L01:
       call      System.Runtime.CompilerServices.CastHelpers.ChkCastClass(Void*, System.Object)
       int       3
; Total bytes of code 42
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.ChkCastClass(Void*, System.Object)
       test      rdx,rdx
       je        short M01_L00
       cmp       [rdx],rcx
       jne       short M01_L01
M01_L00:
       mov       rax,rdx
       ret
M01_L01:
       jmp       qword ptr [7FFBDECAFD08]; System.Runtime.CompilerServices.CastHelpers.ChkCastClassSpecial(Void*, System.Object)
; Total bytes of code 20
```

## .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v3 (Job: DefaultJob)

```assembly
; UnsafeFunThings.UsingUnsafeAs.CastingObjects.CastUsingUnsafeAs()
       mov       rax,[rcx+8]
       ret
; Total bytes of code 5
```