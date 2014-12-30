-- Wrapper for Yutils-ASS => NyuFX-ASS

wrapper = {
	
	fix_line = function(li, line)
		line.infade = line.leadin
		line.outfade = line.leadout
		line.k_text = line.text
		line.text = line.text_stripped
		line.intlead = line.internal_leading
		line.extlead = line.external_leading
	end,
	
	fix_syl = function(si, syl)
		syl.intlead = syl.internal_leading
		syl.extlead = syl.external_leading
	end,
	
	fix_word = function(wi, word)
		word.intlead = word.internal_leading
		word.extlead = word.external_leading
	end,
	
	fix_char = function(ci, char_)
		char_.intlead = char_.internal_leading
		char_.extlead = char_.external_leading
	end,
	
	trim = function(text)
		-- Get prespace, postspace and text between
		local prespace, subtext, postspace = text:match("([ \t]*)([^ \t]*)([ \t]*)")
		-- Return trimmed text and spaces
		return subtext, prespace:len(), postspace:len()
	end,
	
	reparse = function()
		for li, line in ipairs(lines) do
			wrapper.fix_line(li, line)
			
			for si, syl in ipairs(line.syls) do
				wrapper.fix_syl(si, syl)
			end
			
			for wi, word in ipairs(line.words) do
				wrapper.fix_word(wi, word)
			end
			
			for ci, char_ in ipairs(line.chars) do
				wrapper.fix_char(ci, char_)
			end
			
			-- Add word / syl Indexes
			local c_word, c_syl = 1, 1
			for pre_tag, tag_time, post_tag, text in line.k_text:gmatch("{(.-)\\[kK][of]?(%d+)(.-)}([^{]*)") do
				local _text, _prespace, _postspace = wrapper.trim(text)
				local inline_fx = string.match(pre_tag .. post_tag, "\\%-([^\\]*)") or ""
				if _prespace > 0 then c_word = c_word + 1 end
				line.syls[c_syl].word_i = c_word
				if _postspace > 0 then c_word = c_word + 1 end
				c_syl = c_syl + 1
			end
			
			c_word = 1
			ci = 1
			for ci, uchar in line.text:uchars() do
				local char = line.chars[ci]
				if uchar == " " or uchar == "\t" then
					char.word_i = 0
					if ci ~= 1 and line.chars[ci-1] ~= " " and line.chars[ci-1] ~= "\t" then
						c_word = c_word + 1
					end
				else
					char.word_i = c_word
				end
				char.syl_i = 1
				ci = ci + 1
			end
			
			local ci = 1
			for si, syl in ipairs(line.syls) do
				-- Prespace
				for i = 0, syl.prespace - 1 do
					line.chars[ci+i].syl_i = si
				end
				ci = ci + syl.prespace
				-- Characters
				for syl_ci, uchar in syl.text:uchars() do
					line.chars[ci+syl_ci-1].syl_i = si
				end
				ci = ci + syl.text:ulen()
				-- Postspace
				for i = 0, syl.postspace - 1 do
					line.chars[ci+i].syl_i = si
				end
				ci = ci + syl.postspace
			end
		end
	end
	
	
}