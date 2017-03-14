SELECT name, language, percentage
FROM countries
JOIN languages
ON countries.id = languages.country_id
WHERE language = 'Slovene'
ORDER BY percentage DESC;

SELECT countries.name as county_name, COUNT(cities.id) as city_count
FROM countries
JOIN cities 
ON countries.id = cities.country_id
GROUP BY countries.id
ORDER BY city_count DESC;

SELECT cities.name, cities.population
FROM countries
JOIN cities
ON countries.id = cities.country_id
WHERE countries.name = 'Mexico' AND cities.population > 500000
ORDER BY cities.population DESC;

SELECT countries.name, language, percentage
FROM countries
JOIN languages
ON countries.id = languages.country_id
WHERE percentage > 89
ORDER BY percentage DESC;

SELECT countries.name, surface_area, countries.population
FROM countries
WHERE surface_area < 501 AND countries.population > 100000;

SELECT countries.name/*, government_form, life_expectancy, capital*/
FROM countries
WHERE government_form = 'Constitutional Monarchy' AND life_expectancy > 75 AND capital > 200;

SELECT countries.name, cities.name, cities.district, cities.population
FROM countries
JOIN cities
WHERE countries.name = 'Argentina' AND cities.district = 'Buenos Aires' AND cities.population > 500000;

SELECT region, COUNT(countries.id) as countries_in_region
FROM countries
GROUP BY region
