-- WDS SQL
-- https://github.com/WebDevSimplified/Learn-SQL

select * from albums

select top 1 *, (select MIN(release_year) from albums) as oldest_year
from albums

--OR

SELECT top 1 * FROM albums
WHERE release_year IS NOT NULL
ORDER BY release_year

select * from bands
select * from albums


select distinct b.name as [Band Name]
from bands b join albums a on b.id = a.band_id 

--OR

select b.name as [Band Name]
from bands b join albums a on b.id = a.band_id
Group by b.name


--5. Get all Bands that have No Albums

select * from bands
select * from albums

select b.name as [band name]
from bands b left join albums a on b.id = a.band_id
where a.band_id is null

--6. Get the Longest Album
select * from albums
select * from songs

select top 1 a.[name] as [Name], a.release_year as [Release Year] ,SUM(s.[length]) as [Duration]
from albums a join songs s on a.id = s.album_id
group by a.[name], s.[album_id], a.[release_year]
order by [Duration] desc

-- 7. Update the Release Year of the Album with no Release Year

select * from albums

update albums
set release_year = 2000
where id = 4

--12. Get the number of Songs for each Band
select * from bands
select * from albums
select * from songs

select b.[name] as [Band], COUNT(s.[name]) as [Number of Songs]
from 
bands b join albums a on a.band_id = b.id
join songs s on s.album_id = a.id
group by b.[name]


-- 11. Select the longest Song off each Album
select * from albums
select * from songs

select a.[name] as [Album], MAX(s.[length]) as [Duration]
from
albums a join songs s on s.album_id = a.id
group by a.[name]

-- Get the Average Length of every Song
select * from songs

select [name] as [Song], AVG([length])
from songs 
group by [album_id], [name]
