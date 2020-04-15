
## 数据库连接信息

column|value
--|--
host|114.119.181.149
port|3306
password|test123
database|testdb

## 第一题：物业公司数据表操作
> Get a list of tenants who are renting more than one apartment. 

```
select a.TenantName,count(1) 
from Tenants a,AptTenants b 
where a.TenantId = b.TenantId
group by a.TenantId
having count(1) > 1;
```

> Get a list of all buildings and the number of open requests (Requests in which status equals 'Open'). 
```
select b.BuildingName, a.UnitNumber, c.`Status` 
from Apartments a,Buildings b, Requests c 
where a.AptID = c.AptID and a.BuildingID = b.BuildingID
and c.`Status` = 'Open'
```

> Building #3 in Complex #1 is undergoing a major renovation. Implement a query to close all requests from apartments in this building.  
```
update Buildings a,Apartments b, Requests c 
set c.`Status` = 'Close'
where a.BuildingID = b.BuildingID 
and b.AptID = c.AptID
and a.ComplexID = 1 and a.BuildingId = 3;
```

## 第二题：学校数据库操作

> ### 数据库设计

> 学生表：Students

Column|Type|Length|Remark
--|--|--|--
StudentId|int|11|学生ID
StudentName|varchar|255|学生姓名

> 课程表：Course

Column|Type|Length|Remark
--|--|--|--
CourseId|int|11|课程ID
CourseName|varchar|255|课程名

> 结果表：Results

Column|Type|Length|Remark
--|--|--|--
StudentId|int|11|学生ID
CourseId|int|11|课程ID
Score|float|12|得分

> 写一个查询，找出所有平均分在前10%的学生，并且按照他们的成绩从高到低排名。注意：每个学生参加的课程的数量可能不同，平均分指的是学生成绩总分/参加课程的数量。

```
select d.StudentId,e.StudentName,d.Score from (
	select b.StudentId,b.Score, @rowNum:=@rowNum + 1 rId from (
			select StudentId, avg(Score) Score
			from Results a
			group by StudentId
			order by Score desc
	) as b,(select @rowNum:=0) c
) as d, Students e
where d.StudentId = e.StudentId 
and d.rId <= ceiling(@rowNum * 0.1)
```

> ### 第三题：程序题
```
1、做了简化，没有考虑长方体方位，也就是说所生成的长方体的边，都是与x,y z轴平行；
2、定义长方体 8 个点分为上、下各 4 点，下边：A1-A4；上边为：B1-B4，详见demo01.jpeg
3、开发环境为：Mac，已在测试Ubuntu18.04系统中测试、运行通过；
4、开发工具为：VSCode
5、Sdk版本：3.1.200；
```
> ### 测试方法
```
> git clone https://github.com/fengyily/demo.git
> cd demo
> dotnet restore
// 测试两个长方体相交
> dotnet run test
// 测试随机 5 个长方体相交
> dotnet run
```