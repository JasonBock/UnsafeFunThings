| Method                                | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------------- |-----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| SetFieldsAndComputeViaReflection      | 51.1191 ns | 0.9733 ns | 0.9104 ns | 1.000 |    0.02 | 0.0069 |     120 B |        1.00 |
| SetFieldsAndComputeViaUnsafeAccessors |  0.4266 ns | 0.0125 ns | 0.0117 ns | 0.008 |    0.00 |      - |         - |        0.00 |


| Method                    | Mean       | Error     | StdDev    | Ratio  | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------- |-----------:|----------:|----------:|-------:|--------:|-------:|----------:|------------:|
| InvokeDirectly            |  0.0986 ns | 0.0052 ns | 0.0049 ns |   1.00 |    0.07 |      - |         - |          NA |
| InvokeUsingReflection     | 14.4244 ns | 0.0302 ns | 0.0282 ns | 146.68 |    7.08 | 0.0014 |      24 B |          NA |
| InvokeUsingUnsafeAccessor |  0.1022 ns | 0.0018 ns | 0.0017 ns |   1.04 |    0.05 |      - |         - |          NA |