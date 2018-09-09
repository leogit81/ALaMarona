select *
from ALaMarona.dbo.Producto

select *
from ALaMarona.dbo.Pedido p
inner join ALaMarona.dbo.DetallePedido dp on dp.IdPedido = p.Id
inner join ALaMarona.dbo.MovimientoStock ms on ms.id = dp.IdMovimientoStock
where p.Id = 6

select *
from ALaMarona.dbo.MovimientoStock