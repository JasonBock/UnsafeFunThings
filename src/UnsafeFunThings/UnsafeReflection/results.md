| Method                                 | Mean       | Error     | StdDev    | Ratio | Gen0   | Allocated | Alloc Ratio |
|--------------------------------------- |-----------:|----------:|----------:|------:|-------:|----------:|------------:|
| SetFieldsAndComputeViaReflection       | 51.6385 ns | 0.4180 ns | 0.3705 ns | 1.000 | 0.0069 |     120 B |        1.00 |
| SetFieldsAndComputeViaCachedReflection | 33.5862 ns | 0.2402 ns | 0.2129 ns | 0.650 | 0.0069 |     120 B |        1.00 |
| SetFieldsAndComputeViaUnsafeAccessors  |  0.1065 ns | 0.0042 ns | 0.0039 ns | 0.002 |      - |         - |        0.00 |
| SetFieldsAndComputeViaSaferAccessors   |  0.1022 ns | 0.0025 ns | 0.0021 ns | 0.002 |      - |         - |        0.00 |


| Method                    | Mean       | Error     | StdDev    | Ratio  | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------- |-----------:|----------:|----------:|-------:|--------:|-------:|----------:|------------:|
| InvokeDirectly            |  0.1054 ns | 0.0107 ns | 0.0100 ns |   1.01 |    0.13 |      - |         - |          NA |
| InvokeUsingReflection     | 14.6355 ns | 0.0674 ns | 0.0598 ns | 139.93 |   12.44 | 0.0014 |      24 B |          NA |
| InvokeUsingUnsafeAccessor |  0.1034 ns | 0.0032 ns | 0.0029 ns |   0.99 |    0.09 |      - |         - |          NA |