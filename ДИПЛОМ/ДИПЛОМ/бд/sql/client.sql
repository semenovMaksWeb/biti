DROP FUNCTION public.client_insert;
CREATE OR REPLACE FUNCTION public.client_insert(
    _name varchar,
    _description varchar,
    _address varchar,
    _phone varchar
)
RETURNS void
LANGUAGE plpgsql
AS $function$
	BEGIN
        INSERT INTO public.client ("name", description, address, phone) VALUES(_name, _description, _address, _phone);
	END;
$function$;

DROP FUNCTION public.client_get_select;
CREATE OR REPLACE FUNCTION public.client_get_select(_search varchar)
RETURNS Table(id int, name varchar)
LANGUAGE plpgsql
AS $function$
	BEGIN
        return query SELECT c.id, c."name" 
        FROM public.client c 
        WHERE LOWER(c."name") like '%' || LOWER(_search) || '%' 
            or LOWER(c.description) like '%' || LOWER(_search) || '%' 
            or LOWER(c.address) like '%' || LOWER(_search) || '%';
	END;
$function$;

DROP FUNCTION public.client_get;
CREATE OR REPLACE FUNCTION public.client_get()
RETURNS Table(id int, name varchar, description varchar, address varchar, phone varchar)
LANGUAGE plpgsql
AS $function$
	BEGIN
        return query SELECT * FROM public.client;
	END;
$function$;


select * from public.client_get_select('сам')
select * from public.client_get()