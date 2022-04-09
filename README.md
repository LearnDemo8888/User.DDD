简单DDD项目

Domain:实体类，事件，防腐层接口，仓储接口，领域服务

Infrastructure(基础设施)，实体类的配置，DBContext,防腐层接口实现，仓储接口实现

WebAPi:Controller、事件（领域事件，集成事件）的响应类

raw/main/assets/image-20220404151938822.png

raw/main/assets/image-20220404175705352.png

这个架构最重要的是里面的代码依赖原则：**从外向内，并且只有这一个方向。处于内环的代码，不应该知道外环的任何东西**。

从上面图也可以看到，洋葱架构，也使用层的概念。不过，它不同于我们习惯的三层或N层。我们来看看每个层的情况：

- 数据层（Domain Layer）

存在于架构的中心部分，由所有业务数据的实体组成。大多数情况下，就是我们的数据模型。后面的实践代码中，我是用EF（Entity Framework）来操作的数据库。

- 存储层（Repository Layer）

存储层在架构中充当服务层和数据模型之间的纽带，并且在这一层将保持所有数据库操作和应用数据的上下文。通常的做法是接口，用接口来描述数据访问所涉及的读写操作。

- 服务层（Services Layer）

服务层用于实现存储层和项目之间的通信，同时，还可以保存实体的业务逻辑。在这一层，服务接口与实现分离，以实现解耦和焦点分离。

- 用户界面层（UI Layer）

这个不解释了。项目最终对外的一层。注意，这儿可能是网站，也可能是API。不需要纠结有没有实际的界面。咱们的实践代码中，我用的是API。