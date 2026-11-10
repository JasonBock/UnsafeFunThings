| Method                                 | Mean      | Error     | StdDev    | Ratio | Gen0   | Allocated | Alloc Ratio |
|--------------------------------------- |----------:|----------:|----------:|------:|-------:|----------:|------------:|
| SetFieldsAndComputeViaReflection       | 47.360 ns | 0.5649 ns | 0.5284 ns |  1.00 | 0.0069 |     120 B |        1.00 |
| SetFieldsAndComputeViaCachedReflection | 30.976 ns | 0.1387 ns | 0.1297 ns |  0.65 | 0.0069 |     120 B |        1.00 |
| SetFieldsAndComputeViaUnsafeAccessors  |  1.264 ns | 0.0023 ns | 0.0021 ns |  0.03 |      - |         - |        0.00 |
| SetFieldsAndComputeViaSaferAccessors   |  1.083 ns | 0.0022 ns | 0.0021 ns |  0.02 |      - |         - |        0.00 |


| Method                    | Mean       | Error     | StdDev    | Ratio  | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------- |-----------:|----------:|----------:|-------:|--------:|-------:|----------:|------------:|
| InvokeDirectly            |  0.8663 ns | 0.0053 ns | 0.0049 ns |   1.00 |    0.00 |      - |         - |          NA |
| InvokeUsingReflection     | 12.5018 ns | 0.0605 ns | 0.0566 ns |  14.43 |    0.10 | 0.0014 |      24 B |          NA |
| InvokeUsingUnsafeAccessor |  0.8565 ns | 0.0016 ns | 0.0014 ns |   0.99 |    0.01 |      - |         - |          NA |