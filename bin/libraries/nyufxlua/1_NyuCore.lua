-- BASE
function pack(...)
	return arg
end

-- Do a wrapper call for function call.
local function wrapper_call(func, ...)
	result = {pcall(func, ...)}
	if not result[1] then
		error(result[2]:gsub("^.*:.*:%s", ""), 2)
	end
	return select(2, unpack(result))
end

-- TODO: Shape-Funktionen jetzt mit Nachkommastellen! Nur fur 1,99? bei Real!

--VALIDATION
local validator = {

	is_valid_style = function(style)
		return 	type(style) == "table" and
				type(style.fontname) == "string" and 
				type(style.bold) == "boolean" and
				type(style.italic) == "boolean" and
				type(style.underline) == "boolean" and
				type(style.strikeout) == "boolean" and
				type(style.fontsize) == "number" and
				style.fontsize > 0 and
				type(style.scale_x) == "number" and
				style.scale_x > 0 and
				type(style.scale_y) == "number" and
				style.scale_y > 0 and
				type(style.spacing) == "number" and
				style.spacing >= 0
	end

}

-- CONVERT
convert = {}

function convert.ass_rgba(str_a_r, g, b)
	return wrapper_call(Yutils.ass.convert_coloralpha, str_a_r, g, b)
end

function convert.a_to_ass(a)
	return wrapper_call(convert.ass_rgba, a)
end

function convert.ass_to_a(str)
	return wrapper_call(convert.ass_rgba, str)
end

function convert.rgb_to_ass(r,g,b)
	return wrapper_call(convert.ass_rgba, r, g, b)
end

function convert.ass_to_rgb(str)
	return wrapper_call(convert.ass_rgba, str)
end

function convert.shape_to_pixels(shape)
	return wrapper_call(Yutils.shape.to_pixels, shape)
end

function convert.text_to_shape(text, style)
	if not validator.is_valid_style(style) then
		error("Valid style table expected for `style'", 2)
	end
	
	local font_object = wrapper_call(Yutils.decode.create_font,
		style.fontname,
		style.bold,
		style.italic,
		style.underline,
		style.strikeout,
		style.fontsize,
		style.scale_x / 100,
		style.scale_y / 100,
		style.spacing
	)
	return wrapper_call(font_object.text_to_shape, text)
end

function convert.text_to_pixels(text, style, off_x, off_y)
	if off_x == nil and off_y == nil then
		off_x, off_y = 0, 0
	elseif type(off_x) ~= "number" or type(off_y) ~= "number" or
			off_x < 0 or off_x > 1 or off_y < 0 or off_y > 1 then
		error("Valid number and number expected for optional `off_x' and `off_y'", 2)
	end
	--Wenn Nummern nil sin nicht filtern!
	local filtered_shape = wrapper_call(
		shape.filter, 
		wrapper_call(convert.text_to_shape, text, style),
		function(x, y)
			return x + off_x, y + off_y
		end
	)
	return wrapper_call(convert.shape_to_pixels, filtered_shape)
end

function convert.image_to_ass(image)
	return wrapper_call(wrapper_call(Yutils.decode.create_bmp_reader, image).data_text)
end

function convert.image_to_pixels(image)
	local reader = wrapper_call(Yutils.decode.create_bmp_reader, image)
	local packed_data = wrapper_call(reader.data_packed)
	local width, height = wrapper_call(reader.width), wrapper_call(reader.height)
	local pixels = {width = width, height = height, data = packed_data}
	local offset = 1
	
	for y = 1, height do
		for x = 1, width do
			local pixel = packed_data[offset]
			pixel.x = x
			pixel.y = y
			pixel.alpha = pixel.a
			pixel.a = nil
			offset = offset + 1
		end
	end
	return pixels
end

-- MATH
function math.bezier(pct, point_table)
	return {wrapper_call(Yutils.math.bezier, pct, point_table)}
end

function math.degree(vec1, vec2)
	return wrapper_call(Yutils.math.degree, unpack(vec1), unpack(vec2))
end

function math.distance( w, h, d )
	return wrapper_call(Yutils.math.distance, w, h, d)
end

function math.ellipse(x, y, w, h, a)
	return wrapper_call(function()
		local rx, ry = Yutils.math.create_matrix().translate(x, y, 0).scale(w / 2, h / 2, 0).rotate("z", -a).transform(0, -1, 0)
		return rx, ry
	end)
end

function math.ortho(vec1, vec2)
	return wrapper_call(Yutils.math.ortho, unpack(vec1), unpack(vec2))
end

function math.randomsteps(start, ends, step)
	return wrapper_call(Yutils.math.randomsteps, start, ends, step)
end

function math.randomway()
	return math.random(0,1) * 2 - 1
end

function math.rotate(p, axis, angle)
	return wrapper_call(function()
		local x, y, z = Yutils.math.create_matrix().rotate(axis, angle).transform(unpack(p))
		return {x, y, z}
	end)
end

function math.round(num, precision)
	return wrapper_call(Yutils.math.round, num, precision)
end

function math.trim(num, starts, ends)
	return wrapper_call(Yutils.math.trim, num, starts, ends)
end

-- SHAPE
shape = {}

function shape.bounding(shape)
	return wrapper_call(Yutils.shape.bounding, shape)
end

function shape.filter(shape, filter)
	return wrapper_call(Yutils.shape.filter, shape, filter)
end

function shape.split(shape, len)
	return wrapper_call(Yutils.shape.split, wrapper_call(Yutils.shape.flatten, shape), len)
end

function shape.tooutline(shape, width_xy, width_y, mode)
	return wrapper_call(Yutils.shape.to_outline, shape, width_xy, width_y, mode)
end

function shape.move(shape, x, y)
	return wrapper_call(Yutils.shape.move, shape, x, y)
end

function shape.ring(out_r, in_r)
	if type(out_r) ~= "number" or type(in_r) ~= "number" or in_r >= out_r then
		error("valid number and number expected", 2)
	end
	local out_r2, in_r2 = out_r*2, in_r*2
	local off = out_r - in_r
	return string.format("m %s %s b %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s m %s %s b %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s",
		0, out_r,														-- outer move
		0, out_r, 0, 0, out_r, 0,										-- outer curve 1
		out_r, 0, out_r2, 0, out_r2, out_r,								-- outer curve 2
		out_r2, out_r, out_r2, out_r2, out_r, out_r2,					-- outer curve 3
		out_r, out_r2, 0, out_r2, 0, out_r,								-- outer curve 4
		off, off+in_r,													-- inner move
		off, off+in_r, off, off+in_r2, off+in_r, off+in_r2,				-- inner curve 1
		off+in_r, off+in_r2, off+in_r2, off+in_r2, off+in_r2, off+in_r,	-- inner curve 2
		off+in_r2, off+in_r, off+in_r2, off, off+in_r, off,				-- inner curve 3
		off+in_r, off, off, off, off, off+in_r							-- inner curve 4
	)
end

function shape.ellipse(w, h)
	if type(w) ~= "number" or type(h) ~= "number" then
		error("number and number expected", 2)
	end
	local w2, h2 = w/2, h/2
	return string.format("m %s %s b %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s %s",
						0, h2,	-- move
						0, h2, 0, 0, w2, 0,	-- curve 1
						w2, 0, w, 0, w, h2,	-- curve 2
						w, h2, w, h, w2, h,	-- curve 3
						w2, h, 0, h, 0, h2	-- curve 4
	)
end

function shape.heart(size, offset)
	if type(size) ~= "number" or type(offset) ~= "number" then
		error("number and number expected", 2)
	end
	-- Build shape from template
	local shape = string.gsub("m 15 30 b 27 22 30 18 30 14 30 8 22 0 15 10 8 0 0 8 0 14 0 18 3 22 15 30", "%d+", function(num)
		return num / 30 * size
	end)
	-- Shift mid point of heart vertically
	shape = shape:gsub("(m [%d%.]+ [%d%.]+ b [%d%.]+ [%d%.]+ [%d%.]+ [%d%.]+ [%d%.]+ [%d%.]+ [%d%.]+ [%d%.]+ [%d%.]+ [%d%.]+ [%d%.]+ )([%d%.]+)", function(head, y)
		return head .. (y + offset)
	end)
	-- Return result
	return shape
end

function shape.polygon(edges, size)
	local shape, shape_n = {string.format("m 0 %s l", -size)}, 1
	local outer_p
	for i = 1, edges do
		outer_p = math.rotate({0, -size, 0}, "z", (i / edges)*360)
		shape_n = shape_n + 1
		shape[shape_n] = string.format(" %.3f %.3f", outer_p[1], outer_p[2])
	end
	shape = table.concat(shape)
	-- Shift to positive numbers
	local min_x, min_y = 0, 0
	shape:gsub("(%-?[%d%.]+)%s+(%-?[%d%.]+)", function(x, y)
		min_x, min_y = math.min(min_x, x), math.min(min_y, y)
	end)
	shape = shape:gsub("(%-?[%d%.]+)%s+(%-?[%d%.]+)", function(x, y)
		return string.format("%s %s", x-min_x, y-min_y)
	end)
	-- Return result
	return shape
end

local function shape_glance_or_star(edges, inner_size, outer_size, shape_type)
	ad = nil
	if shape_type == "star" then
		ad = "l"
	else
		ad = "b"
	end
	
	-- Build shape
	local shape, shape_n = {string.format("m 0 %s %s", -outer_size, ad)}, 1
	local inner_p, outer_p
	for i = 1, edges do
		--Inner edge
		inner_p = math.rotate({0, -inner_size, 0}, "z", ((i-0.5) / edges)*360)
		--Outer edge
		outer_p = math.rotate({0, -outer_size, 0}, "z", (i / edges)*360)
		-- Add curve
		shape_n = shape_n + 1
		if shape_type == "star" then
			shape[shape_n] = string.format(" %.3f %.3f %.3f %.3f", inner_p[1], inner_p[2], outer_p[1], outer_p[2])
		else
			shape[shape_n] = string.format(" %.3f %.3f %.3f %.3f %.3f %.3f", inner_p[1], inner_p[2], inner_p[1], inner_p[2], outer_p[1], outer_p[2])
		end
	end
	shape = table.concat(shape)
	-- Shift to positive numbers
	local min_x, min_y = 0, 0
	shape:gsub("(%-?[%d%.]+)%s+(%-?[%d%.]+)", function(x, y)
		min_x, min_y = math.min(min_x, x), math.min(min_y, y)
	end)
	shape = shape:gsub("(%-?[%d%.]+)%s+(%-?[%d%.]+)", function(x, y)
		return string.format("%s %s", x-min_x, y-min_y)
	end)
	-- Return result
	return shape
end

function shape.glance(edges, inner_size, outer_size)
	if type(edges) ~= "number" or type(inner_size) ~= "number" or type(outer_size) ~= "number" or edges < 2 then
		error("valid 3 numbers expected", 2)
	end
	
	return shape_glance_or_star(edges, inner_size, outer_size, "glance")
end

function shape.star(edges, inner_size, outer_size)
	if type(edges) ~= "number" or type(inner_size) ~= "number" or type(outer_size) ~= "number" or edges < 2 then
		error("valid 3 numbers expected", 2)
	end
	
	return shape_glance_or_star(edges, inner_size, outer_size, "star")
end

function shape.rectangle(w, h)
	if type(w) ~= "number" or type(h) ~= "number" then
		error("number and number expected", 2)
	end
	return string.format("m 0 0 l %s 0 %s %s 0 %s 0 0", w, w, h, h)
end

function shape.triangle(size)
	if type(size) ~= "number" then
		error("number expected", 2)
	end
	local h = math.sqrt(3) * size / 2
	local base = -h / 6
	return string.format("m %s %s l %s %s 0 %s %s %s", size/2, base, size, base+h, base+h, size/2, base)
end

-- STRING
--[[
UTF16 -> UTF8
--------------
U-00000000 ・U-0000007F: 	0xxxxxxx
U-00000080 ・U-000007FF: 	110xxxxx 10xxxxxx
U-00000800 ・U-0000FFFF: 	1110xxxx 10xxxxxx 10xxxxxx
U-00010000 ・U-001FFFFF: 	11110xxx 10xxxxxx 10xxxxxx 10xxxxxx
U-00200000 ・U-03FFFFFF: 	111110xx 10xxxxxx 10xxxxxx 10xxxxxx 10xxxxxx
U-04000000 ・U-7FFFFFFF: 	1111110x 10xxxxxx 10xxxxxx 10xxxxxx 10xxxxxx 10xxxxxx
]]
function string.ucharrange(s, i)
	return wrapper_call(Yutils.utf8.charrange, s, i)
end

function string.uchars(s)
	return wrapper_call(Yutils.utf8.chars, s)
end

function string.ulen(s)
	return wrapper_call(Yutils.utf8.len, s)
end

-- TABLE
function table.append(t1, t2)
	if type(t1) ~= "table" or type(t2) ~= "table" then
		error("table and table expected", 2)
	end
	local t1_n = #t1
	for i, v in pairs(t2) do
		if tonumber(i) then
			t1_n = t1_n + 1
			t1[t1_n] = v
		else
			t1[i] = v
		end
	end
	return t1
end

function table.copy(old_t, deph)
	return wrapper_call(Yutils.table.copy, old_t, deph)
end

function table.max(t)
	if type(t) ~= "table" then
		error("table expected", 2)
	end
	local n = 0
	for _ in pairs(t) do
		n = n + 1
	end
	return n
end

function table.tostring(t)
	return wrapper_call(Yutils.table.tostring, t)
end

-- UTILS
utils = {}

-- TODO: Usage changed!
function utils.distributor(t)
	if type(t) ~= "table" or #t < 1 then
		error("table expected (not empty)", 2)
	end
	local tc, index = table.copy(t), 1
	local tc_n = #tc
	return function()
		if index > tc_n then index = 1 end
		local val = tc[index]
		index = index + 1
		return val
	end
end

function utils.frames(starts, ends, frame_time)
	if frame_time == nil then frame_time = 24000 / 1001 end
	return wrapper_call(Yutils.algorithm.frames, starts, ends, frame_time)
end

function utils.accelerate(pct, accelerator)
	if type(pct) ~= "number" or
		type(accelerator) ~= "string" and type(accelerator) ~= "number" then
		error("number and string or number expected", 2)
	end
	if type(accelerator) == "number" then
		pct = pct^accelerator
	elseif accelerator == "curve_up" then
		pct = (math.sin( -math.pi/2 + pct * math.pi*2) + 1) / 2
	elseif accelerator == "curve_down" then
		pct = 1 - (math.sin( -math.pi/2 + pct * math.pi*2) + 1) / 2
	else
		error("valid last value expected", 2)
	end
	return pct
end

-- TODO: Doku (Neu)
function utils.interpolate_ass(pct, ...)
	return wrapper_call(Yutils.ass.interpolate_coloralpha, pct, ...)
end

function utils.interpolate(pct, val1, val2, calc)
	if type(pct) ~= "number" or
	not (
		(type(val1) == "number" and type(val2) == "number") or
		(type(val1) == "string" and type(val2) == "string")
	) then
		error("number and 2 numbers or 2 strings and optional string expected", 2)
	end
	-- Calculate acceleration
	if calc	then pct = wrapper_call(utils.accelerate, pct, calc) end
	-- Calculate result
	if type(val1) == "number" then
		return val1 + (val2 - val1) * pct
	else
		return wrapper_call(Yutils.ass.interpolate_coloralpha, pct, val1, val2)
	end
end

function utils.text_extents(text, style)
	if not validator.is_valid_style(style) then
		error("Valid style table expected for `style'", 2)
	end
	
	local font_object = wrapper_call(Yutils.decode.create_font,
		style.fontname,
		style.bold,
		style.italic,
		style.underline,
		style.strikeout,
		style.fontsize,
		style.scale_x / 100,
		style.scale_y / 100,
		style.spacing
	)
	
	local text_data = wrapper_call(font_object.text_extents, text)
	local font_data = wrapper_call(font_object.metrics)
	return text_data.width, text_data.height, font_data.ascent, font_data.descent, font_data.internal_leading, font_data.external_leading
end