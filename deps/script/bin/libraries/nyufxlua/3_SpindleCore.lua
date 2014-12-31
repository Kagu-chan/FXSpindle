local outFName, outF
local pLines, content = 0, nil

local function remove_bom_or_fail(text)
	text = text:gsub("^\239\187\191", "")
	
	if 	text:match("^\254\255") or
		text:match("^\255\254") or
		text:match("^\43\47\118[\56\57\43\47]") or
		text:match("^\247\100\76") or
		text:match("^\221\115\102\115") or
		text:match("^\14\254\255") or
		text:match("^\251\238\40\255?") or
		text:match("^\132\49\149\51") then
		error("Invalid file encoding", 2)
	end
	bytes = pack(string.byte(text, 1, 4))
	if bytes[1] == 0 and bytes[2] == 0 and
		bytes[3] == 254 and bytes[4] == 255 or
	   bytes[1] == 255 and bytes[2] == 254 and
		bytes[3] == 0 and bytes[4] == 0 then
		error("Invalid file encoding", 2)
	end
	
	return text
end

function _init(inp, outp)
	outFName = outp
	if outFName:len() > 0 then outF = io.tmpfile() end
	if inp:len() > 0 then
		local ifile = io.open(inp, "r")
		if ifile then
			content = ifile:read("*a")
			content = remove_bom_or_fail(content)
			ifile:close()
		else
			error("couldn't read input file: " .. inp, 1)
		end
	end
	if outF then
		local template = content:gsub("\nDialogue:", "\nComment:"):gsub("\n+$", "")
		outF:write(template)
	end
	-- Create Parser
	_G.parser = Yutils.ass.create_parser(content)
	-- Parser call
	_G.lines, _G.meta, _G.styles = parser.dialogs(true), parser.meta(), parser.styles()
	-- Reparse data
	wrapper.reparse()
end

function _exit(pTime)
	-- Output buffer exists
	if outF then
		-- Copy buffer to output file
		local oFile = io.open(outFName, "w")
		if oFile then
			outF:seek("set")
			for line in outF:lines() do
				oFile:write(line)
				oFile:write("\n")
			end
			outF:close()
			oFile:close()
			print( string.format("Produced lines: %d\nProcess duration (in seconds): %.3f", pLines, os.clock() - pTime) )
		else
			error("couldn't create output file: " .. outFName, 1)
		end
	end
end

function io.progressbar(pct)
	--TODO
end

function io.write_line(line)
	-- Check line
	if type(line) ~= "table" then
		error("table expected", 2)
	elseif type(line.comment) ~= "boolean" or
		type(line.layer) ~= "number" or
		type(line.start_time) ~= "number" or
		type(line.end_time) ~= "number" or
		line.style == nil or tostring(line.style) == nil or
		line.actor == nil or tostring(line.actor) == nil or
		type(line.margin_l) ~= "number" or
		type(line.margin_r) ~= "number" or
		type(line.margin_v) ~= "number" or
		line.effect == nil or tostring(line.effect) == nil or
		line.text == nil or tostring(line.text) == nil then
		error("valid table expected", 2)
	end
	
	local text = string.format("\n%s: %d,%s,%s,%s,%s,%04d,%04d,%04d,%s,%s",
		line.comment and "Comment" or "Dialogue",
		line.layer,
		Yutils.ass.convert_time(line.start_time),
		Yutils.ass.convert_time(line.end_time),
		tostring(line.style),
		tostring(line.actor),
		line.margin_l,
		line.margin_r,
		line.margin_v,
		tostring(line.effect),
		tostring(line.text)
	)
	
	if outF then
		outF:write(text)
		pLines = pLines + 1
	end
end