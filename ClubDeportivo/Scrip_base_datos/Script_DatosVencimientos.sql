-- ===========================================
-- USAR LA BASE EXISTENTE
-- ===========================================
USE proyecto;

-- ===========================================
-- VERIFICAR LAS CUOTAS EXISTENTES
-- ===========================================
SELECT idcuota, nrosocio, fechavencimiento
FROM cuota;

-- ⚠️ Anotá los 3 IDs de tus cuotas que correspondan a tus 3 socios.
-- Por ejemplo: 1, 2 y 3.
-- Luego ejecutá los siguientes UPDATE con esos IDs.

-- ===========================================
-- 🔴 SOCIO 1 -> VENCIDO (venció hace 10 días)
-- ===========================================
UPDATE cuota
SET fechavencimiento = DATE_SUB(CURDATE(), INTERVAL 10 DAY)
WHERE idcuota = 1;   -- ← cambiá este número según tu primer socio

-- ===========================================
-- 🟡 SOCIO 2 -> PRÓXIMO A VENCER (vence en 3 días)
-- ===========================================
UPDATE cuota
SET fechavencimiento = DATE_ADD(CURDATE(), INTERVAL 3 DAY)
WHERE idcuota = 2;   -- ← cambiá este número según tu segundo socio

-- ===========================================
-- 🟢 SOCIO 3 -> AL DÍA (vence en 25 días)
-- ===========================================
UPDATE cuota
SET fechavencimiento = DATE_ADD(CURDATE(), INTERVAL 25 DAY)
WHERE idcuota = 3;   -- ← cambiá este número según tu tercer socio


-- ===========================================
-- CONSULTA FINAL: VERIFICAR ESTADOS
-- (Es la misma lógica que usa tu formulario)
-- ===========================================
SELECT 
    s.nrosocio,
    CONCAT(u.nombre, ' ', u.apellido) AS NombreCompleto,
    c.mes,
    c.anio,
    c.monto,
    c.fechavencimiento,
    CASE 
        WHEN c.fechavencimiento < CURDATE() THEN 'VENCIDO'
        WHEN DATEDIFF(c.fechavencimiento, CURDATE()) <= 3 THEN 'PRÓXIMO A VENCER'
        ELSE 'AL DÍA'
    END AS Estado
FROM cuota c
INNER JOIN socio s ON c.nrosocio = s.nrosocio
INNER JOIN usuario u ON s.idusuario = u.idusuario
ORDER BY c.fechavencimiento ASC;
